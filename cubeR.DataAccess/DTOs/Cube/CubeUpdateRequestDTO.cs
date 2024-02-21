﻿using System.ComponentModel.DataAnnotations;

namespace cubeR.DataAccess.DTOs.Cube;

//public record CubeUpdateRequestDTO
//{
//    [Required]
//    [MinLength(1, ErrorMessage = "Name cannot be empty!")]
//    [MaxLength(250, ErrorMessage = "Name cannot be more than 250 characters!")]
//    public string Name { get; set; } = string.Empty;

//    [Required]
//    public int SidesCount { get; set; }

//    [Required]
//    public int PiecesCount { get; set; }
//}

public record CubeUpdateRequestDTO(string Name, int SidesCount, int PiecesCount);