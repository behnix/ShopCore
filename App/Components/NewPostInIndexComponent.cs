﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Components
{
    public class NewPostInIndexComponent : ViewComponent
    {
        private readonly IPostService _postService;

        public NewPostInIndexComponent(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("_newPostInIndexComponent", await _postService.GetPublishedPosts(3)));
        }
    }
}
