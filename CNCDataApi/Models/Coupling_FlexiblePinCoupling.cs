﻿namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Coupling_FlexiblePinCoupling
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeNo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "公称转矩")]
        public double? NominalTorque { get; set; }

        [Display(Name = "许用转速_钢")]
        public double? AllowableRotationSpeed_Steel { get; set; }

        [Display(Name = "许用转速_铁")]
        public double? AllowableRotationSpeed_Iron { get; set; }

        [Display(Name = "轴孔直径d1")]
        public double? DiameterOfShaftHole_d1 { get; set; }

        [Display(Name = "轴孔直径d2")]
        public double? DiameterOfShaftHole_d2 { get; set; }

        [Display(Name = "轴孔直径dz")]
        public double? DiameterOfShaftHole_dz { get; set; }

        [Display(Name = "Y型轴孔长度L")]
        public double? LengthOfYTypedShaftHole_L { get; set; }

        [Display(Name = "JJ1Z型轴孔长度L")]
        public double? LengthOfJJ1ZTypedShaftHole_L { get; set; }

        [Display(Name = "JJ1Z型轴孔长度L1")]
        public double? LengthOfJJ1ZTypedShaftHole_L1 { get; set; }

        [Display(Name = "尺寸D")]
        public double? Size_D { get; set; }

        [Display(Name = "质量")]
        public double? Mass { get; set; }

        [Display(Name = "转动惯量")]
        public double? MomentOfInertia { get; set; }

        [Display(Name = "径向许用补偿量")]
        public double? RadialAllowableCompensationAmount_Δy { get; set; }

        [StringLength(10)]
        [Display(Name = "轴向许用补偿量")]
        public string AxialAllowableCompensationAmount_Δy { get; set; }

        [StringLength(10)]
        [Display(Name = "角向许用补偿量")]
        public string AngularAllowableCompensationAmount_Δα { get; set; }

        [Display(Name = "刚度")]
        public double? Stiffness { get; set; }

        [Display(Name = "说明")]
        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}