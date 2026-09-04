# LearnAws

.NET 10 Person API - a learning project for CI/CD, Docker, and (eventually) AWS.

## Docker

Build the image (from the repo root):

```sh
docker build -t learnaws .
```

Run it:

```sh
docker run -p 8080:8080 -e LEARNAWS_EXAMPLE_TOKEN=hi-from-my-terminal -e LEARNAWS_SECRET_TOKEN=thisissecret learnaws
```

Then hit the API:

```sh
curl http://localhost:8080/api/person
```

Stop with Ctrl+C.
