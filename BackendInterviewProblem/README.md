Certainly, Amitai. Here's a README that explains the problem in detail.

---

# Advanced Product Search API Challenge

## Problem Statement

You're tasked with building a REST API for an online store using ASP.NET Core. The primary goal is to create an endpoint that allows users to search, filter, sort, and paginate products based on multiple criteria: `name`, `category`, `price range`, and `sort order`.

## Requirements

1. **Endpoint**: Create a `GET /products` API endpoint.

2. **Query Parameters**: The API should accept the following query parameters:

   - `name`: To filter products by name (partial match).
   - `category`: To filter products by category.
   - `minPrice` and `maxPrice`: To filter products within a price range.
   - `sortOrder`: To sort the product list (`asc` for ascending and `desc` for descending based on price).
   - `pageNumber`: To specify the current page in the paginated list.
   - `pageSize`: To specify the number of items per page.

3. **Response**: Return a filtered, sorted, and paginated list of products based on the query parameters. Include metadata like the current page, total number of pages, and total number of items.

4. **Extensibility**: Design your solution so that it's easy to add more filters or sort options in the future.

## Example Request

```plaintext
GET /products?name=Laptop&category=Electronics&minPrice=500&maxPrice=2000&sortOrder=asc&pageNumber=1&pageSize=20
```

## Evaluation Criteria

- Correctness of the implemented logic.
- Proper use of RESTful principles.
- Code readability and organization.
- Performance considerations.
