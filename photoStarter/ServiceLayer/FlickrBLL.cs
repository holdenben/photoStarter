using System;
using System.Collections;
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
		[DataObjectMethod(DataObjectMethodType.Select, true)]
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

		[DataObjectMethod(DataObjectMethodType.Select, false)]
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

		public static PhotoInfo GetPhotoInfo(string photoId) {
			Flickr flickr = new Flickr(ConfigurationManager.AppSettings["apiKey"],
				ConfigurationManager.AppSettings["sharedSecret"]);

			return flickr.PhotosGetInfo(photoId);
		}

		public static FoundUser GetUserInfo(string userName) {
			Flickr flickr = new Flickr(ConfigurationManager.AppSettings["apiKey"],
			ConfigurationManager.AppSettings["sharedSecret"]);

			return flickr.PeopleFindByUserName(userName);
		}



		public static string GetAllTags(string userId) { 
			var photos = GetPublicUserPhotos(userId);
			var tags = photos.SelectMany(photo => photo.Tags).ToList();

			string result = string.Join(", ", tags);

			return result;
		}

		public static List<Photo> GetPublicUserPhotos(string flickrUserId) {
			Flickr flickr = new Flickr(ConfigurationManager.AppSettings["apiKey"],
			                           ConfigurationManager.AppSettings["sharedSecret"]);

			const int photosPerPage = 500; //max allowed
			const int pageToReturn = 1; //first page

			return string.IsNullOrEmpty(flickrUserId) ? new List<Photo>() : flickr.PeopleGetPublicPhotos(flickrUserId, pageToReturn, photosPerPage, SafetyLevel.None, PhotoSearchExtras.Tags | PhotoSearchExtras.DateTaken).OrderByDescending(p => p.DateTaken).ToList();
		}
	}
}
