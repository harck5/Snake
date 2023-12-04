using UnityEngine;

public class LevelGrid
{
    private Vector2Int foodGridPosition, timeUpPosition, timeDownPosition;
    private GameObject foodGameObject, timeUpGameObject, timeDownGameObject;        

    private int xFoodGridPosition, yFoodGridPosition, xTimeUpPosition, yTimeUpPosition;


    private int width;
    private int height;

    private Snake snake;

    public LevelGrid(int w, int h)
    {
        width = w;
        height = h;
    }

    public void Setup(Snake snake)
    {
        this.snake = snake;
        SpawnFood();
    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            Score.AddScore(Score.POINTS);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SpawnFood()
    {
        // while (condicion){
        // cosas
        // }
        
        // { cosas }
        // while (condicion)
        
        do
        {
            foodGridPosition = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(foodGridPosition) != -1);

        xFoodGridPosition = foodGridPosition.x;
        yFoodGridPosition = foodGridPosition.y;


        foodGameObject = new GameObject("Food");
        timeUpGameObject = new GameObject("TimeUp");
        timeDownGameObject = new GameObject("TimeDown");
        

        SpriteRenderer foodSpriteRenderer = foodGameObject.AddComponent<SpriteRenderer>();
        foodSpriteRenderer.sprite = GameAssets.Instance.foodSprite;
        SpriteRenderer timeUpSpriteRenderer = timeUpGameObject.AddComponent<SpriteRenderer>();
        timeUpSpriteRenderer.sprite = GameAssets.Instance.timeUp;

        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y, 0);
        //timeDownGameObject.transform.position = new(foodGridPosition.x!, foodGridPosition.y!, 0);
    }

    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        int w = Half(width);
        int h = Half(height);
        
        // Me salgo por la derecha
        if (gridPosition.x > w)
        {
            gridPosition.x = -w;
        }
        if (gridPosition.x < -w)
        {
            gridPosition.x = w;
        }
        if (gridPosition.y > h)
        {
            gridPosition.y = -h;
        }
        if (gridPosition.y < -h)
        {
            gridPosition.y = h;
        }

        return gridPosition;
    }

    private int Half(int number)
    {
        return number / 2;
    }
}
