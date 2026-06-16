using System;

namespace MegaDownloader;

public class MEGA_ErrorHandler
{
	public static Exception GetErrorFromMegaResponse(string MEGA_Response, string Context)
	{
		return MEGA_Response switch
		{
			"-1" => CreateException("EINTERNAL - An internal error has occurred [-1].", Context), 
			"-2" => CreateException("EARGS -  You have passed invalid arguments to this command [-2].", Context), 
			"-3" => CreateException("EAGAIN - A temporary congestion or server malfunction prevented your request from being processed. No data was altered [-3].", Context), 
			"-4" => CreateException("ERATELIMIT - You have exceeded your command weight per time quota. Please wait a few seconds, then try again [-4].", Context), 
			"-5" => CreateException("EFAILED - The upload failed. Please restart it from scratch [-5].", Context), 
			"-6" => CreateException("ETOOMANY - Too many concurrent IP addresses are accessing this upload target URL [-6].", Context), 
			"-7" => CreateException("ERANGE - The upload file packet is out of range or not starting and ending on a chunk boundary [-7].", Context), 
			"-8" => CreateException("EEXPIRED - The upload target URL you are trying to access has expired. Please request a fresh one [-8].", Context), 
			"-9" => CreateException("ENOENT - Object (typically, node or user) not found [-9].", Context), 
			"-10" => CreateException("ECIRCULAR - Circular linkage attempted [-10].", Context), 
			"-11" => CreateException("EACCESS - Access violation (e.g., trying to write to a read-only share) [-11].", Context), 
			"-12" => CreateException("EEXIST - Trying to create an object that already exists [-12].", Context), 
			"-13" => CreateException("EINCOMPLETE - Trying to access an incomplete resource [-13].", Context), 
			"-14" => CreateException("EKEY - A decryption operation failed [-14].", Context), 
			"-15" => CreateException("ESID - Invalid or expired user session, please relogin [-15].", Context), 
			"-16" => CreateException("EBLOCKED - User blocked [-16].", Context), 
			"-17" => CreateException("EOVERQUOTA - Request over quota [-17].", Context), 
			"-18" => CreateException("ETEMPUNAVAIL - Resource temporarily not available, please try again later [-18].", Context), 
			_ => CreateException(MEGA_Response, Context), 
		};
	}

	private static Exception CreateException(string text, string Context)
	{
		if (!string.IsNullOrEmpty(Context))
		{
			Context = " " + Context;
		}
		return new ApplicationException("MEGA returned an error" + Context + ". \r\nDetails: " + text);
	}
}
