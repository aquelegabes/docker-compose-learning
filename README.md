# Instructions
### Requirements
* [docker](https://docs.docker.com/get-docker/)
* [docker-compose](https://docs.docker.com/compose/install/)

### Setting containers
On the [docker-compose.yml](https://github.com/gabesantos1/docker-compose-learning/raw/master/docker-compose.yml) VIRTUAL_ENV means what your address should be.
Build the containers using docker-compose build.
<img alt="docker compose build command" src="https://github.com/gabesantos1/docker-compose-learning/raw/master/instructions/docker-compose-build.png">
It shouldn't have any errors on build.

### Setting /etc/hosts
In order to use reversed proxy you'll need to set the hosts file as shown.
<img alt="/etc/hosts file" src="https://github.com/gabesantos1/docker-compose-learning/raw/master/instructions/hosts.png">
the second IP is just to setup for bridge network on VM.

### Running containers
Use docker-compose up to run the containers.
<img alt="docker compose up command" src="https://github.com/gabesantos1/docker-compose-learning/raw/master/instructions/docker-compose-up.png">
With the containers running and hosts setup you'll should be able to connect to your chosen address.
<img alt="app running" src="https://github.com/gabesantos1/docker-compose-learning/raw/master/instructions/app-running.png">

### How the application knows how to correctly connect to the backend api?
The docker containers resolve this conflict using an alias on addresses.
[docker-compose.yml](https://github.com/gabesantos1/docker-compose-learning/raw/master/docker-compose.yml)
<img alt="docker app names" src="https://github.com/gabesantos1/docker-compose-learning/raw/master/instructions/docker-app-names.png">
Where our application name is the address that is setup when a [request is made](https://github.com/gabesantos1/docker-compose-learning/raw/master/web/Pages/Todo/TodoGet.razor.cs).
<img alt="application urls" src="https://github.com/gabesantos1/docker-compose-learning/raw/master/instructions/app-urls.png">