public interface IVideoGamesDeserializer
{
    List<VideoGame>? DeserializeFrom(string fileContents, string fileName);
}