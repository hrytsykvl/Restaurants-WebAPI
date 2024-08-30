# Restaurants Management Web API

Web API for managing restaurants and its dishes, following the principles of Clean Architecture.

## API Endpoints

1. `GET /api/restaurants`

2. `GET /api/restaurants/{id}`
   - Parameters: `id`

3. `GET /api/restaurants/{restaurantId}/dishes`
   - Parameters: `restaurantId`

4. `DELETE /api/restaurants/{restaurantId}/dishes`
   - Parameters: `restaurantId`

5. `GET /api/restaurants/{restaurantId}/dishes/{dishId}`
   - Parameters: `restaurantId`, `dishId`

6. `DELETE /api/restaurants/{id}`
   - Parameters: `id`

7. `PATCH /api/restaurants/{id}`
   - Parameters: `id`
   - Body: JSON object with properties `Name`, `Description`, `HasDelivery`

8. `POST /api/restaurants`
   - Body: JSON object with properties `Name`, `Description`, `Category`, `HasDelivery`, `ContactEmail`, `ContactNumber`, `City`, `Street`, `ZipCode`

9. `POST /api/restaurants/{restaurantId}/dishes`
   - Body: JSON object with properties `Name`, `Description`, `Price`, `Calories`
