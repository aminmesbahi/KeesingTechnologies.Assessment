## Keesing Technologies Assessment

Amin Mesbahi Assessment, Keesing Technologies

**LIVE VERSION:** [kt.assessment.mesbahi.net](https://kt.assessment.mesbahi.net/index.html)
**Docker Hub:** [aminmesbahi - Docker Image | Docker Hub](https://hub.docker.com/r/aminmesbahi/keesingtechnologiesassessmentcalendarserviceapi)

 - [x] Also unit tests developed for REST Services

****

**Running the docker image**
`docker run --rm -it -p 8000:80 -p 8001:443 aminmesbahi/keesingtechnologiesassessmentcalendarserviceapi:latest`
then browse with http://127.0.0.1:8000


## Senior Software Engineer / Full Stack Developer

### APIs

**The following APIs need to be implemented:**

 1. - [x]  Adding a new event - POST request should be created to add a new event. The API endpoint would be /calendar. The request body contains the details of the event. HTTP response should be 201.

 1. - [x]  Deleting any event by id -  DELETE request to endpoint /calendar/{id} should delete the event. If the item does not exist return not found.

1. - [x]  Editing the event - PUT request to endpoint /calendar/{id}. If the item does not exist return not found.

1. - [x]  Getting all events - GET request to endpoint /calendar should return all the events in the system. The HTTP response code should be 200. If no event exists, return the empty array.

1. - [x]  Getting all events of the organizer - GET request to endpoint /calendar/query?eventOrganizer={eventOrganizer} should return the entire list of events organized by this organizer. The HTTP response code should be 200. For empty response return empty array.

1. - [x]  Getting event by id - GET request to endpoint /calendar/{id} should return the details of the event with this unique id. The HTTP response code should be 200.

1. - [x]  Sort the event as per the time - GET request to endpoint /calendar/sort should return the events sorted in descending order of time.

**Deliverables**

 * - [x]  The source code published in your GitHub account.

*  - [x]  A working Docker image published in your account at [http://hub.docker.com](http://hub.docker.com) with the instructions to run it.
