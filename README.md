# aspnetcore-kubernetes
Example service to demonstrate Kubernetes scaling and probes

### Build and run docker image from command line

```powershell
cd <directory containing Dockerfile>
docker image build -t <dockerId>/aspnetcore-kubernetes:1000  .
docker run -d -p 8081:80 <dockerId>/aspnetcore-kubernetes
docker images
Browse to http://localhost:8081
```

### Push image to docker repository
To push to dockerhub.
```powershell
docker login -u <dockerId> -p <password>
docker push <dockerId>/aspnetcore-kubernetes:1000
```


### View Home Page
```powershell
Browse to http://localhost:8081
```

### REST endpoint
`/ping` returns the string 'pong'.
`/info` returns information about the current running application.