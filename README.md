# ceyehat-api
My senior project backend
[![CodeQL](https://github.com/ademclk/ceyehat-api/actions/workflows/codeql.yml/badge.svg?branch=main)](https://github.com/ademclk/ceyehat-api/actions/workflows/codeql.yml)


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
   - **Aircrafts**
      - [Create Aircraft](#create-aircraft)
        - [Create Aircraft Request](#create-aircraft-request)
        - [Create Aircraft Response](#create-aircraft-response)
   - **Customers**
      - [Create Customer](#create-customer)
        - [Create Customer Request](#create-customer-request)
        - [Create Customer Response](#create-customer-response)
   - **Flights**
      - [Create Flight](#create-flight)
        - [Create Flight Request](#create-flight-request)
        - [Create Flight Response](#create-flight-response)
   - **Seats**
      - [Create Seat](#create-seat)
        - [Create Seat Request](#create-seat-request)
        - [Create Seat Response](#create-seat-response)
   - **Prices**
      - [Create Price](#create-price)
        - [Create Price Request](#create-price-request)
        - [Create Price Response](#create-price-response)
        
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

## Create Aircraft

**Requires authorization token.**

### Create Aircraft Request

```http
POST /api/Aircraft
```

```json
{
  "registrationNumber": "TC-JFE",
  "icao24Code": "4BA8C5",
  "model": "Boeing 737-8F2",
  "manufacturerSerialNumber": "29767",
  "faaRegistration": "N1786B",
  "countryId" : "7afcf68f-2f86-4d20-9f02-72c707b31a29",
  "airlineId" : "09f46ed8-ca89-4d8d-ac67-d2fb4b9200b6"
}
```

### Create Aircraft Response

```http
HTTP/1.1 200 OK
```

```json
{
  "id": "0a3901f2-cf62-441e-9ae8-0d3a9e5059c2",
  "registrationNumber": "TC-JFE",
  "icao24Code": "4BA8C5",
  "model": "Boeing 737-8F2",
  "manufacturerSerialNumber": "29767",
  "faaRegistration": "N1786B",
  "countryId": "7afcf68f-2f86-4d20-9f02-72c707b31a29",
  "airlineId": "09f46ed8-ca89-4d8d-ac67-d2fb4b9200b6",
  "flightIds": [],
  "seatIds": [],
  "createdAt": "2023-02-21T10:11:29.506748Z",
  "updatedAt": "2023-02-21T10:11:29.506748Z"
}
```

## Create Customer

**Requires authorization token.**

### Create Customer Request

```http
POST /api/Customer
```

```json
{
  "name": "Test",
  "surname": "Customer",
  "email": "test@customer.com",
  "phoneNumber": "0000001111",
  "title": 0,
  "birthDate": "2023-02-21T13:18:27.199Z",
  "passengerType": 0,
  "userId": null
}
```

### Create Customer Response

```http
HTTP/1.1 200 OK
```

```json
{
  "id": "baff9e0e-c670-4ab2-92b1-207af6f81288",
  "name": "Test",
  "surname": "Customer",
  "email": "test@customer.com",
  "phoneNumber": "0000001111",
  "title": 0,
  "birthDate": "2023-02-21T13:18:27.199Z",
  "passengerType": 0,
  "userId": "77d7e6a0-7f21-4583-b572-bd62e862115f",
  "bookings": [],
  "flightTickets": [],
  "boardingPasses": [],
  "createdAt": "2023-02-21T13:34:07.561229Z",
  "updatedAt": "2023-02-21T13:34:07.561229Z"
}
```

## Create Flight

**Requires authorization token.**

### Create Flight Request

```http
POST /api/Flight
```

```json
{
  "flightNumber": "AI000001",
  "scheduledDeparture": "2023-02-21T16:13:34.240Z",
  "scheduledArrival": "2023-02-21T16:13:34.240Z",
  "status": 0,
  "type": 0,
  "actualDeparture": null,
  "actualArrival": null,
  "aircraftId": "0a3901f2-cf62-441e-9ae8-0d3a9e5059c2",
  "departureAirportId": "f0b4f0f9-496f-4a9f-a60e-bfc63eb91f04",
  "arrivalAirportId": "a5cf68f9-23a3-4385-8bcb-bbd586a4d23b",
  "priceId": "f0b4f0f9-496f-4a9f-a60e-bfc63eb91f04"
}
```

### Create Flight Response 


```http
HTTP/1.1 200 OK
```

```json
{
  "id": "b50106b5-5dc1-4c53-9f07-aab7dd253d18",
  "flightNumber": "AI000001",
  "scheduledDeparture": "2023-02-21T16:13:34.24Z",
  "scheduledArrival": "2023-02-21T16:13:34.24Z",
  "status": "Scheduled",
  "type": "RoundTrip",
  "actualDeparture": null,
  "actualArrival": null,
  "aircraftId": "0a3901f2-cf62-441e-9ae8-0d3a9e5059c2",
  "departureAirportId": "f0b4f0f9-496f-4a9f-a60e-bfc63eb91f04",
  "arrivalAirportId": "a5cf68f9-23a3-4385-8bcb-bbd586a4d23b",
  "priceId": "f0b4f0f9-496f-4a9f-a60e-bfc63eb91f04",
  "createdAt": "2023-02-21T20:55:27.113222Z",
  "updatedAt": "2023-02-21T20:55:27.113222Z"
}
```

## Create Seat

**Requires authorization token.**

### Create Seat Request

```http
POST /api/Seat
```

```json
{
  "seatNumber": "A1",
  "aircraftId": "0a3901f2-cf62-441e-9ae8-0d3a9e5059c2",
  "seatClass": 0,
  "seatStatus": 0
}
```

### Create Seat Response 

```http
HTTP/1.1 200 OK
```

```json
{
  "id": "876898a7-474d-433f-ac14-aad2fea9c264",
  "seatNumber": "A1",
  "seatClass": "Economy",
  "seatStatus": "Available",
  "aircraftId": "0a3901f2-cf62-441e-9ae8-0d3a9e5059c2",
  "createdAt": "2023-02-21T21:19:32.814403Z",
  "updatedAt": "2023-02-21T21:19:32.814404Z"
}
```

## Create Price

**Requires authorization token.**

### Create Price Request

```http
POST /api/Price
```

```json
{
  "amount": 1,
  "currency": 0,
  "pricing": {
    "baseCost": 100,
    "markupPercentage": 10,
    "demandMultiplier": 1,
    "competitionMultiplier": 0.9,
    "seasonalMultiplier": 1.3,
    "lengthMultiplier": 1.5,
    "classMultiplier": 1.2
  }
}
```

### Create Price Response 

```http
HTTP/1.1 200 OK
```

```json
{
  "id": "4879b856-be8a-4593-a772-2350663dbae3",
  "amount": 1,
  "currency": "Usd",
  "pricing": {
    "baseCost": 100,
    "markupPercentage": 10,
    "demandMultiplier": 1,
    "competitionMultiplier": 0.9,
    "seasonalMultiplier": 1.3,
    "lengthMultiplier": 1.5,
    "classMultiplier": 1.2,
    "totalCost": 2316.6000
  },
  "createdAt": "2023-02-21T21:58:39.588187Z",
  "updatedAt": "2023-02-21T21:58:39.588187Z"
}
```


# Disclaimer

This is an educational project.

# License

This project is licensed under the [MIT License](https://github.com/ademclk/ceyehat-api/blob/main/LICENSE)




