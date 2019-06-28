using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public abstract class Animal2
    {
        public abstract string LatinName();

        public string Foo()
        {
            return "Hello World";
        }
    }
    public class Axe : IPutInBag, IDamagable
    {
        public int VolumeInCentiLitres { get => throw new NotImplementedException(); }

        public int GetDamageFactor()
        {
            throw new NotImplementedException();
        }
    }
    public class Bread : IPutInBag
    {
        public int VolumeInCentiLitres { get => throw new NotImplementedException(); }
    }
    public class Horse : Animal2
    {
        public override string LatinName()
        {
            throw new NotImplementedException();
        }
    }
    public class Mouse : Animal2, IPutInBag
    {
        public int VolumeInCentiLitres { get => throw new NotImplementedException(); }

        public override string LatinName()
        {
            throw new NotImplementedException();
        }
    }
    public class Sword : IPutInBag, IDamagable
    {
        public int VolumeInCentiLitres { get => throw new NotImplementedException(); }

        public int GetDamageFactor() => throw new NotImplementedException();
    }

    public interface IPutInBag
    {
        int VolumeInCentiLitres { get; }
    }

    public interface IDamagable
    {
        int GetDamageFactor();
    }

    public class InterfacesDemo2
    {
        public void Run()
        {
            Greet(new Animal2());
            //Greet(new Axe());
            //Greet(new Bread());
            Greet(new Horse());
            Greet(new Mouse());
            //Greet(new Sword());

            //PutInBag(new Animal2());
            PutInBag(new Axe());
            PutInBag(new Bread());
            //PutInBag(new Horse());
            PutInBag(new Mouse());
            PutInBag(new Sword());

            //DoDamageWith(new Animal2());
            DoDamageWith(new Axe());
            //DoDamageWith(new Bread());
            //DoDamageWith(new Horse());
            //DoDamageWith(new Mouse());
            DoDamageWith(new Sword());
        }

        private void Greet(Animal2 animal) { }
        private void PutInBag(IPutInBag item)
        {
            Axe myAxe = item as Axe;
            if (myAxe != null)
            {
                int foo = myAxe.GetDamageFactor();
            }



        }
        private void DoDamageWith(IDamagable item) { }
    }
}
