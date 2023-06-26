# EcoTravel
This project will be build with event driven design

#Catalog.API
creating MongoDB image in the docker desktop 
cd solution root "docker pull mongo"
detach --localhost-portnumber : image-portnumber  --dbname --imagename
starting db "docker run -d -p 27017:27017  --name shopping-mongo mongo"
docker logs -f shopping-mongo
mongo interactive terminal: docker exec -it shopping-mongo /bin/bash
