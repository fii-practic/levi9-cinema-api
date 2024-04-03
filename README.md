## Build and run backend service container

How to build a local version of this image:

    $ docker build -t 617129651895.dkr.ecr.eu-west-1.amazonaws.com/docker-levi9-cinema-api:1 .


How to run a local version of this container (interactive/detached)(brigged/host):

    $ docker run -it -p8181:80 --name levi9-cinema-api --rm 617129651895.dkr.ecr.eu-west-1.amazonaws.com/docker-levi9-cinema-api:1

    $ docker run -d --net host --name levi9-cinema-api --rm 617129651895.dkr.ecr.eu-west-1.amazonaws.com/docker-levi9-cinema-api:1

How to push docker image to registry:

    $ docker push 617129651895.dkr.ecr.eu-west-1.amazonaws.com/docker-levi9-cinema-api:1
