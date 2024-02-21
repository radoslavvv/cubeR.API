using cubeR.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace cubeR.DataAccess.DTOs.Solve;

//public record SolveCreateRequestDTO
//{
//    [Required]
//    [EnumDataType(typeof(SolveType), ErrorMessage = "Invalid Solve Type!")]
//    public string SolveType { get; set; } = string.Empty;

//    public int CubeId { get; set; }

//    [Required]
//    [MinLength(1, ErrorMessage = "Scramble cannot be empty!")]
//    [MaxLength(250, ErrorMessage = "Scramble cannot be more than 250 characters!")]
//    public string Scramble { get; set; } = string.Empty;

//    [Required]
//    public DateTime LoggedDate { get; set; }

//    [Required]
//    [RegularExpression(@"^(\d+):([0-5]?\d):([0-5]?\d):(\d{1,3})$", ErrorMessage = "Invalid Solve Time! Correct Solve Time format: hh:mm:ss:SSS")]
//    public string SolveTime { get; set; } = string.Empty;
//}

public record SolveCreateRequestDTO(string SolveType, int CubeId, string Scramble, DateTime LoggedDate, string SolveTime);