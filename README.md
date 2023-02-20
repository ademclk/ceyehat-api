# ceyehat-api
My senior project backend


# API Definition

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








