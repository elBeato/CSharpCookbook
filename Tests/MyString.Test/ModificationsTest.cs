using Strings;

namespace MyString.Test
{
	public class ModificationsTest
	{
		[Fact]
		public void Test_count_number_of_chars_in_string_with_Linq()
		{
			// Arrange

			// Act
			var expected = Modifications.CountCharsInStrings();

			// Assert
			Assert.Equal("a4b2c3x3", Modifications.CountCharsInStrings());
		}
	}
}