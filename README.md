# CountryApp

---
Thank you for the oppertunity! 
---

## Table of Contents

- [Introduction]
- [Architectural choices]
- [Features]
- [How to Run]
- [Improvements]
- [Contact]

---

## Introduction
This is a rather basic app, i was sure to implement the following based on your request, things such as night mode, basic unit testing on both the backend and frontend, clicking on flags give all the information that was requested aswell. Overall it was a fun little project, and enjoyed writing it, I think towards the end I may have missed a few things. But I did my best with the time I had.

---

## Architectural choices

Originally I wanted the rest api to feed into a DB but there where only 250 items from the countries list, if there where more id push for a DB aswell as a search name endpoint but i decided that the front end is more than capable of handling the data that is there. Now the better way to handle the data would probably be paging with a search endpoint, but i did not have enough time to implement it. Dark mode was an intresting thing to implement, I think next time round I'll start with that. Animations I kept suttle with fading pop ups. But overall SPA are intresting things, I do wish I did abit more research on them. But overall I think its a an okay implementation.

---

## Features
This is a Single page application, made with C# and angular. Mostly made with angular meterial has night mode,
![image](https://github.com/KikatoIV/CountryApplication/assets/39209669/04eaa678-3e27-4bd5-bda8-2a63c9600df3)

![image](https://github.com/KikatoIV/CountryApplication/assets/39209669/8f0fc836-c68f-49b0-b1ce-3af3afbc759c)


A rather snappy and fast search

![image](https://github.com/KikatoIV/CountryApplication/assets/39209669/e6d27ef8-8674-4cf2-b1ef-8a9de69ee611)

suttle fade in animations for pop ups

![image](https://github.com/KikatoIV/CountryApplication/assets/39209669/f59de762-ee6c-46da-a194-1756f0221879)

Small tests across the app

![image](https://github.com/KikatoIV/CountryApplication/assets/39209669/524fda77-2bd0-4085-9833-1f10eac3b99f)

![image](https://github.com/KikatoIV/CountryApplication/assets/39209669/a0e21703-1832-4608-9d3f-44999d559109)

---
## How to Run

There are a few ways to get the project going.

One is the goodold and somewhat trust worthy .bat file I only had the chance to try this one once, only had one extra PC with no dependencies loaded, and it did not work, im hoping with the changes made it will work now

![image](https://github.com/KikatoIV/CountryApplication/assets/39209669/5da3c8bc-a403-49ca-91f6-2843d8296337)

Plan B is to load the project in visual studio press the start button
![image](https://github.com/KikatoIV/CountryApplication/assets/39209669/909b084f-300d-451c-b333-3b66daa6f3fe)


otherwise 
```Commandline
cd ClientApp
npm install
cd CountryApp
dot net build
dot net run
```

## Improvements
- More tests, postman collection, a big blocker for me that i did not overcome was creating tests around in memory cache
- More streamlined start up, publishing this project resulted in some unknowns and decided against it, odd things such as web permissions or web socket disconecting was more previlant and resulted in crashing
- Mapper for the repository, Currently there is a method that maps from the rest countries api to the CountryDto, a mapper would have been a more clean implementation
- Clean up, there may be some things that can be removed or are not currently used

## Contact details

Email: tamatiq@gmail.com
