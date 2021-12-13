# Open Source Summit Japan - Implementing Observability for Kubernetes Application

This source code assumes that you have a running Kubernetes cluster. If you are planning to run this application on a local machine you can use Docker Desktop with Kubernetes or minikube.

## Pre-requisites

1. Kubernetes Cluster (Optional) 
2. Local Machine - Kuebernetes on Docker Desktop (https://andrewlock.net/running-kubernetes-and-the-dashboard-with-docker-desktop/) or Minikube - https://minikube.sigs.k8s.io/docs/start/ 
3. .Net Core 5.0 (https://dotnet.microsoft.com/en-us/download/dotnet) or higher
4. Visual Studio Code (Optional)

## Project Structure

This repository contains two .Net Web API projects,
1. PatientManagement
2. AlleryApi

PatientManagement Microservice has dependency over AllergyApi. The purpose of this application is to demonstrate how you can trace the calls from the application using Jaeger.

You can open the code either in Visual Studio Code or Visual Studio 2019 to run the projects. The IDEs will be able to restore the dependencies for the project once you open it. If you are planning to use any text editor. Open terminal (MAC)/ command prompt (Windows) and `cd <project_location` into the folder and run,
`dotnet restore` to restore the dependencies.

To run the applications use `dotnet run`, make sure you run both the applications.

## Running on Kubernetes

To run the application make sure you have installed Jaeger on Kubernetes. To run the application go to the Deployment folder and run following command to deploy the application on Kubernetes,

`kubectl apply -f Deployment.yaml`

This deploys all the components required to run the application. To access the Patient API in your browser go to http://localhost/patient.

Get Patients API



Add Allergy API




To access the Jaeger UI run to forwared the request to the local port run,

`kubectl port-forward service/simplest-query -n observability --address 0.0.0.0 8085:16686`

Now you should be able to access the UI on port http://localhost:8085
