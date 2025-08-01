﻿using CaseStudyMVC.Dtos;

namespace CaseStudyMVC.Services.Abstract
{
    public interface ITodoItemService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(TodoItemCreateDto dto);
        Task<T> DeleteAsync<T>(int id);
        Task<T> UpdateAsync<T>(int id, TodoItemUpdateDto dto);
    }
}
