using _31.MvvmLightDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31.MvvmLightDemo.Services {
    /// <summary>
    /// 学生类的服务，查找 添加 删除
    /// </summary>
    public class StudentService {
        public List<StudentModel> Students { get; set; }

        /// <summary>
        /// 查询学生信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public List<StudentModel> searchStudent(string keywords) {
            return this.Students.Where(item => item.Name.Equals(keywords)).ToList();
        }

        /// <summary>
        /// 重置查询条件 还原数据
        /// </summary>
        /// <returns></returns>
        public List<StudentModel> resetStudent() {
            return this.Students;
        }

        public void addStudents(StudentModel model) {
            this.Students.Add(model);
        }
    }
}
