using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using FlickrNet;

namespace photoStarter.ServiceLayer
{
	/// <summary>
	/// Helper class for confortable pagining and binding
	/// </summary>
	[DataObject(true)]
	[Serializable]
	public class FlickrBLL {
		[DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
		public static PhotosetPhotoCollection GetPagedSet(string setId, int maximumRows, int startRowIndex) {
			Flickr flickr = new Flickr(ConfigurationManager.AppSettings["apiKey"],
				ConfigurationManager.AppSettings["sharedSecret"]);
			PhotosetPhotoCollection photos = flickr.PhotosetsGetPhotos(setId, GetPageIndex(
				startRowIndex, maximumRows) + 1, maximumRows);

			return photos;
		}

		public static int GetPagedSetCount(string setId) {
			Flickr flickr = new Flickr(ConfigurationManager.AppSettings["apiKey"],
				ConfigurationManager.AppSettings["sharedSecret"]);
			Photoset set = flickr.PhotosetsGetInfo(setId);
			return set.NumberOfPhotos;
		}

		[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
		public static PhotosetCollection GetPhotoSetsByUser(string userId) {
			Flickr flickr = new Flickr(ConfigurationManager.AppSettings["apiKey"],
				ConfigurationManager.AppSettings["sharedSecret"]);

			return flickr.PhotosetsGetList(userId);
		}

		protected static int GetPageIndex(int startRowIndex, int maximumRows) {
			if (maximumRows <= 0)
				return 0;
			else
				return (int)Math.Floor((double)startRowIndex / (double)maximumRows);
		}

		//public static 


	}
}
