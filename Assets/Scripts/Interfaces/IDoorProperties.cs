public interface IDoorProperties
{
    public bool IsOpened { get; set; }
    public bool IsLocked { get; set; }

    public void UnlockDoor();
}
