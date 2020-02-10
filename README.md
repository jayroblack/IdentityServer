# IdentityServer
Development OAuth and OpenId using ASP.Net Core Identity &amp; Identity Server 4

## Reading
* [Introduction to Identity on ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-3.1&tabs=visual-studio)
* [Identity Server 4](http://docs.identityserver.io/en/latest/index.html)

## Why?
My personal philosophy has always been that development should not require connection to the internet.  Granted we need the internet more than ever these days with the advent of modern package management, but this is usually an operation that is not performed every single time I am building and running my application.  Also a lot of common libraries are cached at a higher level that further mitigate this argument.  

There are unexpected benefits that emerge from this philosophy.  For instance anytime that I need to perform some testing while developing or while running short or long running testing suites, I often need to be able to set up external dependencies to operate as I want with custom configuration.  

### Examples Please?
1. When the individual development teams are iteratig on their development they will frequently need to be able to create new test users to test out an existing flow.  Along with email verification this can become a very difficult scenario to manage.  In this case each developer has their own version of the Identity Server leaving them free to make as many users as they desire without worrying about clashing with others.  Usually I have them run in the mode that persists their version of the database so they are free to decide for themselves when it should be reset or not.  

2. Technically while running integration tests I should not be accessing the actual database etc.   However lately I have found that using docker containers that run tiny but functional versions of the services I need work better than writing the old fashioned "Fakes".  This gives me the complete control that I crave, without being forced sacrifice testing my code adequately.  Last I run the integration server in a start fresh mode every single time to ensure that we begin with a clean slate every single time.  

3. In this modern age, when interacting with enterprise level SSO Federated Authentication, we have to take on the additional burden of having our testing suites get around Captcha and 2 Factor Authentication.  These technologies were actually created to prevent the testing that I am working to create.  By having my own server that implements the same Token structure and standards, I can be sure that my application will interact as designed in production without having to test against those enterprise hardened servers.  

> NOTE:  For the email verification situation - there is a really cool version where if the email server is not configured on Identity server, it shows you the email to click on to verify the email so you can move on with your tests.  

## Will you use a service for Production?  
Professionally I will almost always make use of Okta, Auth0, or Incognito in order to manage this layer.  I am in total agreement that it just does not make sense to write this code any longer when we can depend on an external service to do it for us better at a reasonable price.  Also while a lot of open source options exist like this one or Ory Hydra, etc - I just find the convenience of not having to manage any of it convenient because I can focus on my core concerns and avoid having to administer larger surface area.  

## Goal of this Project:  
To ease the process of developing services that will eventually be protected by oAuth and OpenId in production, without having to use free developer community environments.  

## Features
1.  The entire solution should run inside of a docker container that exposese the appropriate ports and endpoints for managing the supported Grant Flows as well as  Registering and Managing Users.  
2.  The docker continer should have 2 different modes:
     * Runs with a mounted drive so that changes to the DB are persisted between runs. 
     * Runs without a mounted drive and resets the database on each run so that we are sure we begin with a clean slate.  
3. The docker container should be versionable so that as we develop and add new features such as token field design, etc we can bind the project to the correct version.  
> **NOTE: This core Docker image is versioned, your own changes should be layered on top of the appropriate tagged version so that you can update your project as this project is iterated on to get the latest features, security fixes and performance improvements.**
