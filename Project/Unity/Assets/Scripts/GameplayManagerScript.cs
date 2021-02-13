public class GameplayManagerScript
{
    private int floorActual = 0;

    public int GetFloor()
    {
        return floorActual;
    }
    
    public void NextFloor()
    {
        floorActual++;
    }
}
