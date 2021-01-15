This **Xamarin.Forms** appliaction is written for **Android & iOS devices**. This application can be used by handball team, because it contains features such as:
 - news,
 - points table,
 - fixtures,
 - informations about players,
 - informations about sponsors,
 - live score
 - user profile.

Application is using **Firebase Authentication** to authenticate users, so you have to create account if you want to use this app.

There are a few things that you should do in order to run this appliaction, because it is using **Wordpress CMS REST Api** (so you need to have your own website) and **Firebase Realtime Database** to store fixtures, table & live score data.

You have to add appliaction (Android & iOS) to your Firebase project and download **Google Services config files**. Place **google-services.json** file in **MTSChrzanow/MTSChrzanow.Android** (set Build Action to GoogleServicesJson) and **GoogleService-Info.plist** file in **MTSChrzanow/MTSChrzanow.iOS** (set Build Action to BundleResource)..

It is also important, to make your **Firebase Realtime Database** structure look like:

```
your-project-.
              | - games
              | - realtime
              |           'games
               'table
```

For example:

```
{
  "games" : [ {
    "away" : "Team 1 name",
    "away-goal" : "22",
    "away-logo-url" : "https://somewebsite.com/logos/team-1-logo.png",
    "date-of-game" : "19.09.2020 18:00:00",
    "home" : "Team 2 name",
    "home-goal" : "24",
    "home-logo-url" : "https://somewebsite.com/logos/team-2-logo.png",
    "is-finished" : true
  }, {
    "away" : "Team 3 name",
    "away-goal" : "",
    "away-logo-url" : "https://somewebsite.com/logos/team-3-logo.png",
    "date-of-game" : "07.11.2020 18:00:00",
    "home" : "Team 4 name",
    "home-goal" : "",
    "home-logo-url" : "https://somewebsite.com/logos/team-4-logo.png",
    "is-finished" : false
  } ],
  "realtime" : {
    "games" : {
      "-some-id" : {
        "away" : "Team 1 name",
        "away-goal" : "20",
        "away-logo-url" : "https://somewebsite.com/logos/team-1-logo.png",
        "home" : "Team 2 name",
        "home-goal" : "50",
        "home-logo-url" : "https://somewebsite.com/logos/team-2-logo.png",
        "is-going" : false
      }
    }
  },
  "table" : [ {
    "draws-losses" : "0",
    "draws-wins" : "0",
    "goals-against" : "22",
    "goals-for" : "24",
    "logo-url" : "https://somewebsite.com/logos/team-1-logo.png",
    "losses" : "0",
    "name" : "Team 1 name",
    "wins" : "1"
  }, {
    "draws-losses" : "0",
    "draws-wins" : "0",
    "goals-against" : "53",
    "goals-for" : "50",
    "logo-url" : "https://somewebsite.com/logos/team-2-logo.png",
    "losses" : "2",
    "name" : "Team 2 name",
    "wins" : "0"
  } ]
}
```

You also need to create `config.json` file in shared project directory (**MTSChrzanow/MTSChrzanow**) that will contain your project url and some endpoints.

```
{
  "ApiUrl": "https://yourwordpresswebsite.com/wp-json/wp/v2/",
  "ApiPostsUrl": "posts",
  "ApiPostsFromPageUrl": "posts?page=",
  "ApiSinglePostMedia": "media/",
  "ApiFirebaseUrl": "https://your-firebase-project-name.firebaseio.com/",
  "ApiFirebaseGamesUrl": "games.json",
  "ApiRealTimeGameChild": "realtime/games",
  "ApiFirebaseAuth": "?auth=",
  "ApiWPTotalPages": "X-WP-TotalPages",
  "ApiFirebaseTableUrl": "table.json"
}

```

## TODO:
 - tests,
 - dark theme support,
 - cache images & other data,
 - app localization & string resources,
 - bug fixes,
 - ...
