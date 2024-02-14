using FluentValidation;
using RecipeOrganization.Core.Domain.RequestModels;

namespace RecipeOrganization.Core.Domain.CustomValidations;

public class RecipeValidation : AbstractValidator<RecipeRequestModel>
{
}
