This is .Net WebAPI application. 
It is designed to retrieve countries from open API.
The sequence of countries can be filtered by Country Name using filtering value as attribute
and Population searching for countries where the population is less than provided number in the millions of people.

To Run application locally: 
1. Clone this repository to your machine.
2. Navigate to the directory where you saved the application.
3. Navigate to the folder Net_AI_UseCase1.
4. Run command `dotnet run`
5. Use generated Url + `/swagger` to navigate to swagger and try out endpoint functionality.

Example urls how to use developed endpoint:

/api/Countries?filterPopulation=-1&rowCount=-1&order=ascend
/api/Countries?filterPopulation=-1&rowCount=-1&order=descend
/api/Countries?filterPopulation=-1&rowCount=0&order=ascend
/api/Countries?filterPopulation=-1&rowCount=20&order=ascend
/api/Countries?filterPopulation=0&rowCount=-1&order=ascend
/api/Countries?filterPopulation=100&rowCount=-1&order=ascend
/api/Countries?filterCountryName=sT&filterPopulation=-1&rowCount=-1&order=ascend
/api/Countries?filterCountryName=USA&filterPopulation=-1&rowCount=-1&order=ascend
/api/Countries?filterCountryName=sT&filterPopulation=15&rowCount=40&order=ascend
/api/Countries?filterCountryName=sT&filterPopulation=15&rowCount=40&order=descend



