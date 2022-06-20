# Animal Shelter

## By **Evgeniya Meshuris**

### This is an API built for adding animals in shelter.

## Technologies Used 🖥️

* _C#_
* _.Net 6.0_
* _Git_
* _VsCode_
* _EntityFrameWork_
* _REPL_
* _MySQL WorkBench_
* _API_
* _Swagger_

## Description ✅

This webpage was programmed using C#, ASP.NET & Entity. It is an API that allows to add animals to API database. The properties for each are name and a type (0-cats, 1-dogs) . When the page is ran it will open the localhost:5000/index.html page showing the swagger UI. From the swagger UI the user can interact directly with the API database. Full CRUD functionality is available.

## Setup/Installation Requirements 🖊️

* _Clone this repo: <https://github.com/evmeshuris/AnimalShelterApi.Solution.git>_
* _Enter the new directory using the command ```cd AnimalShelterApi.Solution```_
* _In the root directory, confirm there is a .gitignore file_
* _add:_

```js
*/obj,
*/bin
*.vscode
*/appsettings.json
```

* _From the root directory, navigate to the directory named "AnimalShelter"_
* _Using terminal run dotnet restore && dotnet build && dotnet watch run_
* _When the app runs it will automatically open a webpage and display the Swagger UI for the API_


## Swagger

![Alt text](https://raw.githubusercontent.com/evmeshuris/AnimalShelterApi.Solution/main/AnimalShelter/wwwroot/img/pic.png)

* _You can select any of the drop downs (GET, GET/{id}, POST, etc.)_
* _From there, you can see what keys are available for GET methods_
* _You can see the Request Body for Post/Put Methods_
* _You can see what key is required for Delete Method_
* _You can also click the "Try it out" button in the top right of the drop down, this will allow you to interact with the database directly_
* _Versions_
    * _V1_
        * Description: Fully working api without authentication
        * Example Usage: Use swagger as described above
    * _V2_
        * Description: Fully working api *with* authentication
        * Example Usage: Use/modify the script below:

```shell
curl --location --request GET \
'http://localhost:5240/v2/AnimalShelter' \
--header 'X-API-Key: bingobongo123'
```

## Known Bugs 🐛

* _Please refer to the issues section of the repo_

## License

[MIT](LICENSE)



Copyright (c) 2022, Evgeniya Meshuris
