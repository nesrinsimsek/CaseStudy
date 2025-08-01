# CaseStudy

## Project Structure

This project is built using a **layered architecture**. It is structured into the following layers:

* **Api**
* **Business**
* **DataAccess**
* **Presentation**

## Running the Project

To run the API, set the **CaseApi** project located in the **Api** folder as the **startup project**.

You can interact with the database through the available endpoints using **Swagger UI**.

## Implemented Endpoints

All endpoints requested in the task documentation have been implemented and work as expected:

* GET /api/todoitems
* GET /api/todoitems/{id}
* POST /api/todoitems
* PUT /api/todoitems/{id}
* DELETE /api/todoitems/{id}

To ensure that created items are user-specific, I added a **Users** table to the database and established a foreign key relationship through the **User_Id** field in the **TodoItems** table.

Additionally, I created the following endpoints to manage users:

* GET /api/users – Retrieves all users
* GET /api/users/{id} – Retrieves a specific user by ID

## Running API and MVC Together

To run both the API and the MVC application simultaneously, configure **multiple startup projects** and select:

* **CaseApi** (located in the Api folder) – **Start**
* **CaseStudyMVC** (located in the Presentation folder) – **Start**
* All other projects – **None**

## Using the Application

When the project starts, the initial screen will be a **Create To-Do List** form.

In the navigation bar, you will see two buttons:

* **Create To-Do List**
* **View To-Do Lists**

On the Create screen, you can select a user from the dropdown, fill in the required fields, and click **Add** to save the item to the database. You will then be redirected to the **View To-Do Lists** screen.

On the item listing screen, you can:

* View details of the items
* Use the **Delete** button next to an item to remove it from the database
* See a **Complete** button, which currently **does not** update the IsCompleted field in the database. (This functionality is not fully working on the UI yet, but I plan to improve and fix it with further development.)

However, **all CRUD operations** are fully functional and testable through the API endpoints.

