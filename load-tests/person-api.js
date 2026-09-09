import http from 'k6/http';
import { check, sleep } from 'k6';

// Tunables come from the environment so the workflow's dispatch inputs can
// drive the same script without editing it.
const BASE_URL = __ENV.BASE_URL || 'http://localhost:8080';
const VUS = Number(__ENV.VUS || 10);
const DURATION = __ENV.DURATION || '30s';
const RAMP_UP = __ENV.RAMP_UP || '10s';
const RAMP_DOWN = __ENV.RAMP_DOWN || '5s';
const P95_MS = Number(__ENV.P95_MS || 300);

export const options = {
  stages: [
    { duration: RAMP_UP, target: VUS },   // climb to the target concurrency
    { duration: DURATION, target: VUS },  // steady state - the part worth measuring
    { duration: RAMP_DOWN, target: 0 },   // let in-flight iterations finish cleanly
  ],
  thresholds: {
    // Thresholds set the exit code, which is what makes this a gate rather
    // than a report: a breach fails the step and therefore the job.
    http_req_failed: ['rate<0.01'],
    http_req_duration: [`p(95)<${P95_MS}`],
    checks: ['rate>0.99'],
  },
};

export default function () {
  const list = http.get(`${BASE_URL}/api/person`, {
    tags: { name: 'list-people' },
  });
  check(list, {
    'list: status is 200': (r) => r.status === 200,
    'list: contains Alice': (r) => r.body.includes('Alice'),
  });

  const one = http.get(`${BASE_URL}/api/person/2`, {
    tags: { name: 'get-person' },
  });
  check(one, {
    'get: status is 200': (r) => r.status === 200,
    'get: is Bilal': (r) => r.body.includes('Bilal'),
  });

  sleep(1); // think-time: without it each VU hammers as fast as the server allows
}
