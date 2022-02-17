<h1>Contacts Web API</h1>

<p style="font:italic;"> This project is a simple Contacts app as a Web API integrated with
local PostgreSQL database using SwaggerUI as test interface.<b>.NET 6.0</b> is used in this 
project.
</p>

<h3>Prerequisites</h3>
<p>
For testing, you need to install <b>PostgreSQL</b> and an IDE if none exists.Visual Studio 
2022 Community Edition is recommended since this repository includes the whole solution. 
You can choose any IDE you like which supports <b>.NET 6.0</b>. If you prefer using different 
database system, don't forget to refactor controller, context and connection string for your 
needs. When using different database system, refactoring the migration is also recommended.  
</p>

<h5>Assumptions</h5>
<p> It is assumed that you have installed <b>PostgreSQL</b> with default settings and 
<b>Visual Studio 2022 Community Edition</b> as IDE. 
</p>

<h3>How To Use This Project</h3>

<ol>
    <li>Open the solution in Visual Studio.</li>
    <li>Start the database migration. If you already have a database and want to use it, 
you can skip this step.</li>
    <li>Run the application.</li>
</ol>

<p>
Application opens your default browser with SwaggerUI at the specified URL. You can also 
check database operations using <b>RDBMS Tools</b> such as <i>pgAdmin</i>.
</p>

<p>
Feel free to ask your questions at <a href="mailto:yavuzavci@gmail.com">yavuzavci@gmail.com</a>.
</p>