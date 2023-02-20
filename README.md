# ceyehat-api
My senior project backend

---

### Index
- [API Definition](#api-definition)
  - **Users**
    - [User Registration](#user-registration)
      - [User Register Request](#user-register-request)
      - [User Register Response](#user-register-response)
    - [User Login](#user-login)
      - [User Login Request](#user-login-request)
      - [User Login Response](#user-login-response)
   - **Countries**
      - [Create Country](#create-country)
        - [Create Country Request](#create-country-request)
        - [Create Country Response](#create-country-response)
   - **Cities**
      - [Create City](#create-city)
        - [Create City Request](#create-city-request)
        - [Create City Response](#create-city-response)
   - **Airlines**
      - [Create Airline](#create-airline)
        - [Create Airline Request](#create-airline-request)
        - [Create Airline Response](#create-airline-response) 
   - **Airports**
      - [Create Airport](#create-airport)
        - [Create Airport Request](#create-airport-request)
        - [Create Airport Response](#create-airport-response) 
   

---

# API Definition

_All requests shown here can be found at ceyehat/Requests_

## User Registration

### User Register Request
```http
POST /api/auth/register
```

```json
{
  "email": "test@github.com",
  "password": "Test12345",
  "firstname": "Github",
  "lastname":"Test"
}
```


### User Register Response
```http
HTTP/1.1 200 OK
```

```json
{
  "accessToken": "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI1NzQyMGQwMy1lOGIxLTRjOTctOTFkZC01ZTI3Mjk2YmFlNzEiLCJnaXZlbl9uYW1lIjoiR2l0aHViIiwiZmFtaWx5X25hbWUiOiJUZXN0IiwianRpIjoiODFjOWE1MjctYzdkZC00MTUwLTljNzctZTdhM2FiMzU2ZDc5IiwiZXhwIjoxNjc2ODgyMzg0LCJpc3MiOiJBZGVtQ0xLIiwiYXVkIjoiQWRlbUNMSyJ9.yD0rtDvkOW2Dlh4cDiDEYNoma5KX4CQd1fq2XXZlTCD1FGdFYjzYvPo4JcMffWVrsVj87anJomkSXxaYEwxtVQ",
  "expireDate": "2023-02-20T08:39:44.001838Z",
  "refreshToken": "ce8982d7-5127-4fce-95f2-de9c0229af77"
}
```

## User Login

### User Login Request

```http
POST http://localhost:5228/api/auth/login
```

```json
{
  "email": "test@github.com",
  "password": "Test12345"
}
```

### User Login Response

```http
HTTP/1.1 200 OK
```

```json
{
  "accessToken": "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI1NzQyMGQwMy1lOGIxLTRjOTctOTFkZC01ZTI3Mjk2YmFlNzEiLCJnaXZlbl9uYW1lIjoiR2l0aHViIiwiZmFtaWx5X25hbWUiOiJUZXN0IiwianRpIjoiMjA2YzFmZTctNjhiMi00Y2Y5LWE2MzktMzE1ZmRjZTgxNmRmIiwiZXhwIjoxNjc2ODgyOTU0LCJpc3MiOiJBZGVtQ0xLIiwiYXVkIjoiQWRlbUNMSyJ9.bMOqX_ulZSLVmoQr_mbj0D4NGYLv4Sgs3ozuuHQUITUQpqMe5dzjrvcvjV0Kelgb_QHapt7D6cf6GiuuakYZNg",
  "expireDate": "2023-02-20T08:49:14.310414Z",
  "refreshToken": "747a9500-ee48-4279-862b-f983e6b56632"
}
```

## Create Country

**Requires authorization token.**

### Create Country Request

```http
POST /api/Country
```

```json
{
  "unLocode": "792",
  "name": "Türkiye",
  "iso2": "TR",
  "iso3": "TUR",
  "currency": 15
}
```

### Create Country Response

```http
HTTP/1.1 200 OK
```

```json
{
  "id": "7afcf68f-2f86-4d20-9f02-72c707b31a29",
  "unLocode": "792",
  "name": "Türkiye",
  "iso2": "TR",
  "iso3": "TUR",
  "currency": 15,
  "aircraftIds": [],
  "airlineIds": [],
  "cityIds": [],
  "createdAt": "2023-02-20T09:14:04.770867Z",
  "updatedAt": "2023-02-20T09:14:04.770867Z"
}
```

## Create City

**Requires authorization token.**

### Create City Request

```http
POST /api/City
```

```json
{
  "Name": "İstanbul",
  "CountryId": "7afcf68f-2f86-4d20-9f02-72c707b31a29",
  "Districts": [
    {
      "Name": "Pendik",
      "Neighborhoods": [
        {
          "Name": "Sanayi"
        }
      ]
    }
  ]
}
```

### Create City Response

```http
HTTP/1.1 200 OK
```

```json
{
  "id": "e0b9aab2-e1e1-4fbc-9aa9-10988fc15764",
  "name": "İstanbul",
  "countryId": "7afcf68f-2f86-4d20-9f02-72c707b31a29",
  "districts": [
    {
      "id": "fbaf912a-4e74-4908-9763-5b4fbf80d3ec",
      "name": "Pendik",
      "neighborhoods": [
        {
          "id": "23f03723-7a09-40e3-ba61-e777005de2c8",
          "name": "Sanayi",
          "airlineId": null,
          "airportId": null
        }
      ]
    }
  ],
  "createdAt": "2023-02-20T11:37:33.372649Z",
  "updatedAt": "2023-02-20T11:37:33.372649Z"
}
```

## Create Airline

**Requires authorization token.**

### Create Airline Request 

```http
POST /api/Airline
```

```json
{
  "name": "Turkish Airlines",
  "iataCode": "TK",
  "icaoCode": "THY",
  "callsign": "TURKISH",
  "code": "235",
  "website": "https://www.turkishairlines.com",
  "address": {
    "cityId": "b936bdcc-5bec-4660-b296-682fb142e5c5"
  },
  "aircraftIds": [
    ""
  ]
}
```

### Create Airline Response

```http
HTTP/1.1 200 OK
```

```json
{
  "id": "09f46ed8-ca89-4d8d-ac67-d2fb4b9200b6",
  "name": "Turkish Airlines",
  "iataCode": "TK",
  "icaoCode": "THY",
  "callsign": "TURKISH",
  "code": "235",
  "website": "https://www.turkishairlines.com",
  "address": {
    "city": "b936bdcc-5bec-4660-b296-682fb142e5c5"
  },
  "aircraftIds": [],
  "createdAt": "2023-02-20T18:58:00.195811Z",
  "updatedAt": "2023-02-20T18:58:00.195811Z"
}
```

## Create Airport

**Requires authorization token.**

### Create Airport Request

```http
POST /api/Airport
```

```json
{
  "name": "Sabiha Gökçen Uluslararası Havalimanı",
  "cityId": "b936bdcc-5bec-4660-b296-682fb142e5c5",
  "iataCode": "SAW",
  "icaoCode": "LTFJ",
  "latitude": 40.9054302267176,
  "longitude": 29.31685227451326,
  "timezone": "GMT+03:00"
}
```

### Create Airport Response

```http
HTTP/1.1 200 OK
```

```json
{
  "id": "36c66a4f-dc74-4c70-8823-e02583cfe285",
  "name": "Sabiha Gökçen Uluslararası Havalimanı",
  "cityId": "b936bdcc-5bec-4660-b296-682fb142e5c5",
  "iataCode": "SAW",
  "icaoCode": "LTFJ",
  "latitude": 40.9054302267176,
  "longitude": 29.31685227451326,
  "timezone": "GMT+03:00",
  "departureFlights": [],
  "arrivalFlights": [],
  "createdAt": "2023-02-20T21:14:49.184471Z",
  "updatedAt": "2023-02-20T21:14:49.184471Z"
}
```


# Disclaimer

This is an educational project.

# License

This project is licensed under the [MIT License](https://github.com/ademclk/ceyehat-api/blob/main/LICENSE)




