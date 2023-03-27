using System;

namespace ConsoleApp43
{
    public interface ICharacter
    {
        int Attack { get; }
        int Speed { get; }
        int Health { get; }
        int Defense { get; }
        void Move();
    }

    // Базовый класс персонажа
    public class Character : ICharacter
    {
        public virtual int Attack => 0;
        public virtual int Speed => 0;
        public virtual int Health => 0;
        public virtual int Defense => 0;
        public virtual void Move() => Console.WriteLine("Character moves.");
    }

    // Декоратор для добавления модификатора скорости
    public class SpeedModifier : ICharacter
    {
        private readonly ICharacter _component;
        private readonly int _speedModifier;

        public SpeedModifier(ICharacter component, int speedModifier)
        {
            _component = component;
            _speedModifier = speedModifier;
        }

        public int Attack => _component.Attack;
        public int Speed => _component.Speed + _speedModifier;
        public int Health => _component.Health;
        public int Defense => _component.Defense;

        public void Move()
        {
            Console.WriteLine($"Character moves with speed {_component.Speed + _speedModifier}.");
            _component.Move();
        }
    }

    // Конкретные классы персонажей
    public class Human : Character
    {
        public override int Speed => 20;
        public override int Health => 150;
    }

    public class HumanWarrior : Character
    {
        public override int Attack => 20;
        public override int Speed => 10;
        public override int Health => 50;
        public override int Defense => 20;
    }

    public class Swordsman : HumanWarrior
    {
        public override int Attack => 40;
        public override int Speed => -10;
        public override int Health => 50;
        public override int Defense => 40;
    }

    public class Archer : HumanWarrior
    {
        public override int Attack => 20;
        public override int Speed => 20;
        public override int Health => 50;
        public override int Defense => 10;
    }

    public class Horseman : Swordsman
    {
        public override int Attack => -10;
        public override int Speed => 40;
        public override int Health => 200;
        public override int Defense => 100;
    }

    public class Elf : Character
    {
        public override int Speed => 15;
        public override int Health => 100;
    }

    public class ElfWarrior : Elf
    {
        public override int Attack => 20;
        public override int Speed => -10;
        public override int Health => 100;
        public override int Defense => 20;
    }

    public class ElfWizard : Elf
    {
        public override int Attack => 10;
        public override int Speed => 10;
        public override int Health => -50;
        public override int Defense => 10;
    }

    public class Crossbowman : ElfWarrior
    {
        public override int Attack => 20;
        public override int Speed => 10;
        public override int Health => 50;
        public override int Defense => -10;
    }

    public class EvilWizard : ElfWizard
    {
        public override int Attack => 70;
        public override int Speed => 20;
        public override int Health => 0;
        public override int Defense => 0;
    }

    public class ProfessionDecorator : Character
    {
        protected Character character;


        public ProfessionDecorator(Character profession)
        {
            this.character = profession;
        }

        public override int Attack()
        {
            return profession.Attack();
        }

        public override int Speed()
        {
            return profession.Speed();
        }

        public override int Health()
        {
            return profession.Health();
        }

        public override int Defense()
        {
            return profession.Defense();
        }

        public class WarriorDecorator : ProfessionDecorator
        {
            public WarriorDecorator(Character profession) : base(profession)
            {
            }
        }

        public override int Attack()
        {
            return profession.Attack() + 20;
        }

        public override int Speed()
        {
            return profession.Speed() + 10;
        }

        public override int Health()
        {
            return profession.Health() + 50;
        }

        public override int Defense()
        {
            return profession.Defense() + 20;
        }
    }

    public class SwordsmanDecorator : ProfessionDecorator
    {
        public SwordsmanDecorator(Character profession) : base(profession)
        {
        }
        public override int Attack()
        {
            return profession.Attack() + 40;
        }

        public override int Speed()
        {
            return profession.Speed() - 10;
        }

        public override int Health()
        {
            return profession.Health() + 50;
        }

        public override int Defense()
        {
            return profession.Defense() + 40;
        }
    }
    public class ArcherDecorator : ProfessionDecorator
    {
        public ArcherDecorator(Character profession) : base(profession)
        {
        }
        public override int Attack()
        {
            return profession.Attack() + 20;
        }

        public override int Speed()
        {
            return profession.Speed() + 20;
        }

        public override int Health()
        {
            return profession.Health() + 50;
        }

        public override int Defense()
        {
            return profession.Defense() + 10;
        }
    }
    public class CavalryDecorator : ProfessionDecorator
    {
        public CavalryDecorator(Character profession) : base(profession)
        {
        }
        public override int Attack()
        {
            return profession.Attack() - 10;
        }

        public override int Speed()
        {
            return profession.Speed() + 40;
        }

        public override int Health()
        {
            return profession.Health() + 200;
        }

        public override int Defense()
        {
            return profession.Defense() + 100;
        }
    }
    public class ElfDecorator : ProfessionDecorator
    {
        public ElfDecorator(Character profession) : base(profession)
        {
        }
        public override int Speed()
        {
            return profession.Speed() + 15;
        }

        public override int Health()
        {
            return profession.Health() + 30;
        }
    }
    public class ElfWarriorDecorator : ElfDecorator
    {
        public ElfWarriorDecorator(Character profession) : base(profession)
        {
        }
        public override int Attack()
        {
            return profession.Attack() + 20;
        }

        public override int Speed()
        {
            return profession.Speed() - 10;
        }

        public override int Health()
        {
            return profession.Health() + 100;
        }

        public override int Defense()
        {
            return profession.Defense() + 20;
        }
    }
    public class ElfMage : ProfessionDecorator
    {
        public ElfMage(Character character) : base(character)
        {
            AttackModifier = 10;
            SpeedModifier = 10;
            HealthModifier = -50;
            DefenseModifier = 10;
        }
    }

    public class Arbalestier : ProfessionDecorator
    {
        public Arbalestier(Character character) : base(character)
        {
            AttackModifier = 20;
            SpeedModifier = 10;
            HealthModifier = 50;
            DefenseModifier = -10;
        }
    }

    public class EvilMage : ProfessionDecorator
    {
        public EvilMage(Character character) : base(character)
        {
            AttackModifier = 70;
            SpeedModifier = 20;
            HealthModifier = 0;
            DefenseModifier = 0;
        }
    }

    public class GoodMage : ProfessionDecorator
    {
        public GoodMage(Character character) : base(character)
        {
            AttackModifier = 50;
            SpeedModifier = 30;
            HealthModifier = 100;
            DefenseModifier = 30;
        }
    }
    class Programm
    {
        var character = new HumanWarrior();
        character = new Archer(character);
        character = new Arbalestier(character);
        character = new GoodMage(character);

        character.Move(10, 10); 
    }
}