# COVID-19 Application 
The Covid-19 Application is created and built on Unity. It allows users to search and view Covid-19 data for any country the Covid-19 API has recorded. The application also has a map function which highlights the areas that are most affected by the virus. 

## User Stories
- This application will allow users to view COVID-19 data from the COVID-19 API.
- This application should be able to present data to the user via a map. 
- This application will be built off of Unity with the ability to be cross-platform.

## Explanation of the Application
The application has two main functions, viewing country data and summarizing data on a world map. As seen in the screenshot below the two functions are to be selected from the main menu. 
![Main Menu](https://github.com/BUEC500C1/codvid-app-sz64/blob/master/Main_Menu.png)

### Country Data
In this section the user will see a summary of the current recorded totals of the data on the left, and be able to see up to date information for a country they search for on the right. If the country is not in the database or the user misentered the country there will be an error. 
![Country Data](https://github.com/BUEC500C1/codvid-app-sz64/blob/master/Country_Data.png)

### Map Data
In this section the user will see a world map with separations at country borders. The different buttons on the bottom will highlight the map based off of different datasets. Currently 10 of the most affected countries are implemented into the system, but all of the countries could be added in a similar fashion. Darker red color means that the country has the highest numbers, while more faded shades of red signify lower numbers. Gray countries are countries that are not included in the system. 
![Map Data](https://github.com/BUEC500C1/codvid-app-sz64/blob/master/Map_Data.png)

## Installation
There is currently a zip folder with a .exe version of the application included in this repository, but the application can also be built for other platforms, verification that other platforms work when built has not been tested, but other platforms include Android, iOS, and MAC.

Secondly a video of the application being used is included as a .flv video file in the repository. 

## Backlog
 - More countries added to the map.
 - Different methods to organize the highlighting on the map.
  - For example normalizing for population or other factors. 
