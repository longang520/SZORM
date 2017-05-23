﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace SZORM.Core.Emit
{
    public static class EmitHelper
    {
        public static void SetValueIL(ILGenerator il, MemberInfo member)
        {
            MemberTypes memberType = member.MemberType;
            if (memberType == MemberTypes.Property)
            {
                MethodInfo setter = ((PropertyInfo)member).GetSetMethod();
                il.EmitCall(OpCodes.Callvirt, setter, null);//给属性赋值
            }
            else if (memberType == MemberTypes.Field)
            {
                il.Emit(OpCodes.Stfld, ((FieldInfo)member));//给字段赋值
            }
            else
                throw new NotSupportedException();
        }
    }
}
