﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SASSTS2.Application.Behaviors;
using SASSTS2.Application.Exceptions;
using SASSTS2.Application.Models.Dtos.CategoryDtos;
using SASSTS2.Application.Models.RequestModels.CategoriesRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Validators.CategoryValidators;
using SASSTS2.Application.Wrapper;
using SASSTS2.Domain.Entities;
using SASSTS2.Domain.UWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public CategoryService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<List<CategoryDto>>> GetAllCategories()
        {
            var result = new Result<List<CategoryDto>>();

            var categoryEntites = await _unitWork.GetRepository<Category>().GetAllAsync();
            var categoryDtos = await categoryEntites.ProjectTo<CategoryDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = categoryDtos;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetCategoryByIdValidator))]
        public async Task<Result<CategoryDto>> GetCategoryById(GetCategoryByIdVM getCategoryByIdVM)
        {
            var result = new Result<CategoryDto>();

            var categoryExists = await _unitWork.GetRepository<Category>().AnyAsync(x => x.Id == getCategoryByIdVM.Id);
            if (!categoryExists)
            {
                throw new NotFoundException($"{getCategoryByIdVM.Id} numaralı kategori bulunamadı.");
            }

            var categoryEntity = await _unitWork.GetRepository<Category>().GetById(getCategoryByIdVM.Id);

            var categoryDto = _mapper.Map<Category, CategoryDto>(categoryEntity);

            result.Data = categoryDto;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(CreateCategoryValidator))]
        public async Task<Result<int>> CreateCategory(CreateCategoryVM createCategoryVM)
        {
            var result = new Result<int>();

            var categoryExistsSameName = await _unitWork.GetRepository<Category>().AnyAsync(x => x.CategoryName == createCategoryVM.CategoryName);
            if (categoryExistsSameName)
            {
                throw new AlreadyExistsException($"{createCategoryVM.CategoryName} isminde bir kategori zaten mevcut.");
            }

            var categoryEntity = _mapper.Map<CreateCategoryVM, Category>(createCategoryVM);

            _unitWork.GetRepository<Category>().Add(categoryEntity);
            await _unitWork.CommitAsync();

            result.Data = categoryEntity.Id;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(DeleteCategoryValidator))]
        public async Task<Result<int>> DeleteCategory(DeleteCategoryVM deleteCategoryVM)
        {
            var result = new Result<int>();

            var categoryExists = await _unitWork.GetRepository<Category>().AnyAsync(x => x.Id == deleteCategoryVM.Id);
            if (!categoryExists)
            {
                throw new NotFoundException($"{deleteCategoryVM.Id} numaralı kategori bulunamadı.");
            }

            _unitWork.GetRepository<Category>().Delete(deleteCategoryVM.Id);
            await _unitWork.CommitAsync();

            result.Data = deleteCategoryVM.Id;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(UpdateCategoryValidator))]
        public async Task<Result<int>> UpdateCategory(UpdateCategoryVM updateCategoryVM)
        {
            var result = new Result<int>();

            var existsCategory = await _unitWork.GetRepository<Category>().GetById(updateCategoryVM.Id);
            if (existsCategory is null)
            {
                throw new NotFoundException($"{updateCategoryVM} numaralı kategori bulunamadı.");
            }


            var updatedCategory = _mapper.Map(updateCategoryVM, existsCategory);

            _unitWork.GetRepository<Category>().Update(updatedCategory);
            await _unitWork.CommitAsync();

            result.Data = updatedCategory.Id;
            _unitWork.Dispose();
            return result;
        }
    }
}
