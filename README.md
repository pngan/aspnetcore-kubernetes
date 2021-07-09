# aspnetcore-kubernetes
Example service to demonstrate Kubernetes scaling and probes

### Build docker image

```powershell
cd <directory containing Dockerfile>
docker image build -t pngan/aspnetcore-kubernetes:1000 .
```

### Push image to docker repository
To push to dockerhub.
```powershell
docker login -u pngan -p <password>
docker push pngan/aspnetcore-kubernetes:1000
```

### Run docker container

```powershell
docker run -d -p 8081:80 pngan/aspnetcore-kubernetes:1000
Browse to http://localhost:8081
```

### View Home Page
```powershell
Browse to http://localhost:8081
```

### Run REST GET endpoints
`/ping` returns the string 'pong'.
`/info` returns information about the current running application.