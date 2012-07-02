namespace Primitives.Notes
{
    public class NoteDocument
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public static string GetKey(string noteId)
        {
            return "NoteDocument/" + noteId;
        }
    }
}
