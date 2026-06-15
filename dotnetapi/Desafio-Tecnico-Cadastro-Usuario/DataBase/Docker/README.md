# Docker

reference: https://blog.logrocket.com/docker-sql-server/
or video : https://www.youtube.com/watch?v=RAE-VcZ3u2A&t=151s

1 - Make sure to have Docker running in your local machine for linux container. run command "docker-compose ps" to verify that.

2 -  Run command "docker-compose up -d" to download the mssql server image on linux and create the container and run

3 - Run command "docker-compose ps". you will see that container sql-server-db is running

4 - Use Sql server management studio as shown in the image to create the database:
ServerName : localhost
User       : sa
Password   : change_this_password