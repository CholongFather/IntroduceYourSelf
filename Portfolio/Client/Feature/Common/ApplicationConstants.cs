namespace Portfolio.Client.Common;

public static class ApplicationConstants
{
	public static readonly List<string> _supportedImageFormats = new() { ".jpeg", ".jpg", ".png" };

	public static readonly string _standardImageFormat = "image/jpeg";
	public static readonly int _maxImageWidth = 1500;
	public static readonly int _maxImageHeight = 1500;
	public static readonly long _maxAllowedSize = 1000000; // Allows Max File Size of 1 Mb.
}