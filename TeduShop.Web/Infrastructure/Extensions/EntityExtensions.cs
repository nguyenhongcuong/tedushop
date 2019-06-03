﻿using TeduShop.Model.Models;
using TeduShop.Web.Models;

namespace TeduShop.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory,
            PostCategoryViewModel postCategoryViewModel)
        {
            postCategory.Id = postCategoryViewModel.Id;

            postCategory.Name = postCategoryViewModel.Name;

            postCategory.Alias = postCategoryViewModel.Alias;

            postCategory.ParentId = postCategoryViewModel.ParentId;

            postCategory.DisplayOrder = postCategoryViewModel.DisplayOrder;

            postCategory.Image = postCategoryViewModel.Image;

            postCategory.Description = postCategoryViewModel.Description;

            postCategory.HomeFlag = postCategoryViewModel.HomeFlag;

            postCategory.CreatedDate = postCategoryViewModel.CreatedDate;

            postCategory.CreatedBy = postCategoryViewModel.CreatedBy;

            postCategory.UpdatedDate = postCategoryViewModel.UpdatedDate;

            postCategory.UpdatedBy = postCategoryViewModel.UpdatedBy;

            postCategory.MetaKeyword = postCategoryViewModel.MetaKeyword;

            postCategory.MetaDescription = postCategoryViewModel.MetaDescription;

            postCategory.Status = postCategoryViewModel.Status;

        }

        public static void UpdatePost(this Post post, PostViewModel postViewModel)
        {
            post.Id = postViewModel.Id;
            post.Name = postViewModel.Name;
            post.Alias = postViewModel.Alias;
            post.CategoryId = postViewModel.CategoryId;
            post.Image = postViewModel.Image;
            post.MoreImages = postViewModel.MoreImages;
            post.Description = postViewModel.Description;
            post.Content = postViewModel.Content;
            post.HomeFlag = postViewModel.HomeFlag;
            post.HotFlag = postViewModel.HotFlag;
            post.ViewCount = postViewModel.ViewCount;
            post.CreatedDate = postViewModel.CreatedDate;
            post.CreatedBy = postViewModel.CreatedBy;
            post.UpdatedDate = postViewModel.UpdatedDate;
            post.UpdatedBy = postViewModel.UpdatedBy;
            post.MetaKeyword = postViewModel.MetaKeyword;
            post.MetaDescription = postViewModel.MetaDescription;
            post.Status = postViewModel.Status;
        }
    }
}