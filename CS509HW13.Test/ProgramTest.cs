using Xunit;
using FluentAssertions;
using AutoFixture;
using Moq;

namespace CS509HW13.Test
{
    public class TestA
    {
        [Fact]
        public void f1_should_add_one_to_input()
        {
            int x = new Fixture().Create<int>();
            A.f1(x).Should().Be(x + 1);
        }

        [Fact]
        public void f2_should_add_two_to_input()
        {
            int x = new Fixture().Create<int>();
            A.f2(x).Should().Be(x + 2);
        }

        // Skipping A.f3 because it is protected

        // Skipping A.f4 because it is private

        [Fact]
        public void f5_should_divide_input_parameters()
        {
            Fixture fixture = new();
            Generator<int> generator = fixture.Create<Generator<int>>();
            int[] nums = generator.Where(x => x != 0).Take(2).ToArray();
            A.f5(nums[0], nums[1]).Should().Be(nums[0] / nums[1]);
        }

        [Fact]
        public void f5_should_throw_divide_by_zero_exception_if_second_parameter_is_zero()
        {
            int x = new Fixture().Create<int>();
            int y = 0;
            Action act = () => A.f5(x, y);
            act.Should().Throw<DivideByZeroException>();
        }

        [Fact]
        public void f6_should_throw_exception_when_x_is_negative()
        {
            int x = new Fixture().Create<int>() * -1;  // fixture always creates positive integers
            Action act = () => A.f6(x);
            act.Should().Throw<Exception>().WithMessage("x can't be negative");
        }

        [Fact]
        public void f6_should_add_5_when_x_is_positive()
        {
            int x = new Fixture().Create<int>();
            A.f6(x).Should().Be(x + 5);
        }

        [Fact]
        public void f6_should_add_5_when_x_is_zero()
        {
            A.f6(0).Should().Be(5);
        }

        [Fact]
        public void f7_should_add_more_stuff_to_input_string()
        {
            string s = new Fixture().Create<string>();
            A.f7(s).Should().Be(s + " more stuff");
        }

        [Fact]
        public void f8_should_add_eight_to_input()
        {
            int x = new Fixture().Create<int>();
            new A().f8(x).Should().Be(x + 8);
        }
    }

    public class TestB
    {
        [Fact]
        public void g1_should_return_f8_output()
        {
            var a = new Mock<IA>();
            int num = new Fixture().Create<int>();
            a.Setup(x => x.f8(It.IsAny<int>())).Returns(num);
            B.g1(num, a.Object).Should().Be(num);
        }
    }
}
