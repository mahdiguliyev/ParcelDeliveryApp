<div align="center">
  <h1>ParcelDelivery Microservices App</h1>
</div>

<p>
  In the project, there are 2 microservices:
</p>
<ul>
  <li>Authentication</li>
  <li>Parcel.API</li>
</ul>

<p>General flow of the project architecture:</p>

![Image](https://github.com/user-attachments/assets/9ed29ddd-75bf-47f3-8909-bf5481512ff2)

<p>Authentication - in the microservice, Idendity and Jwt Bearer Token is used for authentication and authorization processes. The microservice is responsible for login and registration of users to authorize and autheticate to call other microservices' apis (example: Parcel.API).</p>
<ul>
  <li>Structure of the project: Clean Architecure</li>
  <li>ORM: Entity Framework Core</li>
  <li>Database: Postgre SQL</li>
  <li>Containerization: Docker</li>
</ul>

<p>Parcel.API - The microservice is reponsible to manage parcel delivery orders.</p>
<ul>
  <li>Structure of the project: Clean Architecure</li>
  <li>ORM: Entity Framework Core</li>
  <li>Database: MSSQL Server</li>
  <li>Desing Patterns: Repository, CQRS via MediatR</li>
  <li>Containerization: Docker</li>
</ul>

<p>PDApiGateway - is an api gateway which is responsible to forward clients' request to related microservice.</p>
<ul>
  <li>Packeg: Ocelot</li>
</ul>


<h3>To run application, follow below steps:</h3>

<h4>Step 1</h4>
<p> - Fetch the project</p>

<h4>Step 2</h4>
<p> - Redirect to folder: /src. Run following command: </p>
<code>docker-compose up -d</code>

<h4>If you are trying to run application on localhost do following before step 3 and 4:</h4>
<p>Change database ‘Host’ (PostgreSQL) and 'Server' (MSSQL) name to localhost in <code>appsettings.json</code> for both Authentication and Parcel.API microservices.</p>

<h4>Step 3</h4>
<p>Redirect to folder: src\Services\Auth\Authentication.Persistance. Run following command:</p>
<code>dotnet ef database update</code>

<h4>Step 4</h4>
<p>Redirect to folder: src\Services\Parcel\Parcel.Persistance. Run following command:</p>
<code>dotnet ef database update</code>
<h4></h4>
<p><strong>Note:</strong> after doing all steps, guid for the seed data are generated automatically while seeding. Change them depend on your cases.</p>
<p>For example: to assing a role to the user run following script: </p>
<code>insert into "UserRoles" values('userId','roleId')</code>

<h4></h4>
<p>If the project is running on docker, you can test apis over Api Gateway.</p>
<p>Api Endpoint: <code>http://http:/localhost:4444/gw/</code></p>
<p>Swagger Endpoint: <code>http://http:/localhost:4444/swagger</code></p>
