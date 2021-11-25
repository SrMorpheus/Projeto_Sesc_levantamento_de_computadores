FROM mysql:5.7.22
EXPOSE 3306


COPY ./Projeto_Inventáro/Models/Script  /home/database/
COPY ./Projeto_Inventáro/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh