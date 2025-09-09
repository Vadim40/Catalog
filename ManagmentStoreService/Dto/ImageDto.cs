namespace ManagmentStoreService.Dto
{
    public class ImageDto
    {
        public int Id { get; init; }
        public string Url { get; init; }
        public bool IsMain { get; init; }

        public string PublicId { get; init; }
    }
}
