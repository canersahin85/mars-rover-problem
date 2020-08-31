﻿namespace Rover.Test
{
    using Xunit;
    using Rover;

    public class RoverTest
    {
        /// <summary>
        /// max coodinates : 5 5
        /// input : 1 2 N
        /// input : LMLMLMLMM
        /// output: 1 3 N
        /// </summary>
        [Fact]
        void Scenario_1_2_N_LMLMLMLMM()
        {
            var model = new MarsRover(1, 2, 'N', "LMLMLMLMM");

            //İstenilen maksimum hücreli grid i oluşturuyoruz.
            Grid _testGrid = new Grid(new Coordinates(5, 5));

            //örnek rover inputlarını ekliyoruz
            _testGrid.AddToRoverCollection(model);

            //rover ı istenilen koordinatlarda hareket ettiriyoruz.
            _testGrid.MoveAllRoversOnGrid();

            //Rover ın varış noktasını output değerini kontrol ediyoruz.
            var actualOutput = $"{model.X} {model.Y} {model.RoverDirection}";
            var expectedOutput = "1 3 N";

            //istenilen output kod çıktısı ile aynı mı?
            Assert.Equal(expectedOutput, actualOutput);
        }

        /// <summary>
        /// max coodinates : 5 5
        /// input : 3 3 E
        /// input : MMRMMRMRRM
        /// output: 5 1 E
        /// </summary>
        [Fact]
        void Scenario_3_3_E_MMRMMRMRRM()
        {
            //test senaryosunda istenilen değerleri giriyoruz.
            var model = new MarsRover(3, 3, 'E', "MMRMMRMRRM");

            //İstenilen maksimum hücreli grid i oluşturuyoruz.
            Grid _testGrid = new Grid(new Coordinates(5, 5));

            //örnek rover inputlarını ekliyoruz
            _testGrid.AddToRoverCollection(model);

            //rover ı istenilen koordinatlarda hareket ettiriyoruz.
            _testGrid.MoveAllRoversOnGrid();

            //Rover ın varış noktasını output değerini kontrol ediyoruz.
            var actualOutput = $"{model.X} {model.Y} {model.RoverDirection}";
            var expectedOutput = "5 1 E";

            //istenilen output kod çıktısı ile aynı mı?
            Assert.Equal(expectedOutput, actualOutput);

        }
    }
}
