namespace PCQueue;

public interface IJob
{
    public void Execute();
    public string GetInfo();            // FOR DEBUG
}
