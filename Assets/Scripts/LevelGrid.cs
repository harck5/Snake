using UnityEngine;

public class LevelGrid
{
    private Vector2Int foodGridPosition, timeUpGridPosition, timeDownGridPosition;
    private GameObject foodGameObject, timeUpGameObject, timeDownGameObject;
    
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
        SpawnTimeUp();
        SpawnTimeDown();
    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            Score.AddScore(Score.FOODPOINTS);
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool TrySnakeEatTimeUp(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == timeUpGridPosition)
        {
            Object.Destroy(timeUpGameObject);
            SpawnTimeUp();
            Score.AddScore(Score.TIMEUPPOINTS);
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool TrySnakeEatTimeDown(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == timeDownGridPosition)
        {
            Object.Destroy(timeDownGameObject);
            SpawnTimeDown();
            Score.AddScore(Score.TIMEDOWNPOINTS);
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
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(foodGridPosition) != -1 || 
        foodGridPosition == timeUpGridPosition || foodGridPosition == timeDownGridPosition);
        //While, a parte de tener en cuenta la lista de posiciones del cuerpo tambien tendra en cuenta la posicion de las demas frutas para que no coincidan
        
        foodGameObject = new GameObject("Food");
        SpriteRenderer foodSpriteRenderer = foodGameObject.AddComponent<SpriteRenderer>();
        foodSpriteRenderer.sprite = GameAssets.Instance.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y, 0);
    }


    private void SpawnTimeUp()
    {
        do
        {
            timeUpGridPosition = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(timeUpGridPosition) != -1 ||
        timeUpGridPosition == foodGridPosition || timeUpGridPosition == timeDownGridPosition);

        timeUpGameObject = new GameObject("TimeUp");
        SpriteRenderer timeUpSpriteRenderer = timeUpGameObject.AddComponent<SpriteRenderer>();
        timeUpSpriteRenderer.sprite = GameAssets.Instance.timeUpSprite;
        timeUpGameObject.transform.position = new Vector3(timeUpGridPosition.x, timeUpGridPosition.y, 0);
    }


    private void SpawnTimeDown()
    {
        do
        {
            timeDownGridPosition = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(timeDownGridPosition) != -1 ||
        timeDownGridPosition == foodGridPosition || timeDownGridPosition == timeUpGridPosition);

        timeDownGameObject = new GameObject("TimeDown");
        SpriteRenderer timeDownSpriteRenderer = timeDownGameObject.AddComponent<SpriteRenderer>();
        timeDownSpriteRenderer.sprite = GameAssets.Instance.timeDownSprite;
        timeDownGameObject.transform.position = new Vector3(timeDownGridPosition.x, timeDownGridPosition.y, 0);
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
