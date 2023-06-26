# EcoTravel
This project will be build with event driven design

# 
**Catalog.API**

##CatalogDb##

creating MongoDB image in the docker desktop 
```
cd solution root "docker pull mongo"
detach --localhost-portnumber : image-portnumber  --dbname --imagename
starting db "docker run -d -p 27017:27017  --name shopping-mongo mongo"
docker logs -f shopping-mongo
mongo interactive terminal: docker exec -it shopping-mongo /bin/bash
root@22b4af4f6d89:/# mongosh
```
https://www.mongodb.com/docs/mongodb-shell/crud/read/

##Create a New Database and Collection
To create a new database, issue the use <db> command with the database that you would like to create.
```
use CatalogDb
db.create.Collection('Products')
db.Products.insertMany([{
Name: "Acer Notebooks",
Catagory: "Computer",
Summary: "Acer Nitro 5 12.Nesil Core i7 12700H-8Gb-512Gb Ssd-15.6inc-Rtx3060 6Gb-",
Description: "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC ",
ImageUrl: "https://picsum.photos/id/9/5000/3269",
Price:"54.93"
}])
>db.products.find()

>show databases
```

