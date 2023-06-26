# EcoTravel
This project will be build with event driven design

#Catalog.API
creating MongoDB image in the docker desktop 
cd solution root "docker pull mongo"
detach --localhost-portnumber : image-portnumber  --dbname --imagename
starting db "docker run -d -p 27017:27017  --name shopping-mongo mongo"
docker logs -f shopping-mongo
mongo interactive terminal: docker exec -it shopping-mongo /bin/bash
root@22b4af4f6d89:/#    type mongosh 
use CatalogDb

##Create a New Database and Collection
To create a new database, issue the use <db> command with the database that you would like to create.
