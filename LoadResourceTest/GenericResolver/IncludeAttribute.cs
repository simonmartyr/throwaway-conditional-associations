using System;
namespace LoadResourceTest.GenericResolver
{
  [AttributeUsage(AttributeTargets.Property)]
  public class ConditionalInclude : Attribute
  {
    public ConditionalInclude()
    {

    }
  }
}
