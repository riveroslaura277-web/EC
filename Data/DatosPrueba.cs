using EC.Models;

namespace EC.Data
{
    public static class DatosPrueba
    {
        public static List<Estudiante> Estudiantes() => new()
        {
            new Estudiante { Id=1,  Codigo="EST001", Nombres="Ana",       Apellidos="García",   Grado=1, Estado="Activo"   },
            new Estudiante { Id=2,  Codigo="EST002", Nombres="Luis",      Apellidos="Martínez", Grado=1, Estado="Activo"   },
            new Estudiante { Id=3,  Codigo="EST003", Nombres="María",     Apellidos="López",    Grado=1, Estado="Inactivo" },
            new Estudiante { Id=4,  Codigo="EST004", Nombres="Pedro",     Apellidos="Ramírez",  Grado=1, Estado="Activo"   },
            new Estudiante { Id=5,  Codigo="EST005", Nombres="Laura",     Apellidos="Torres",   Grado=2, Estado="Activo"   },
            new Estudiante { Id=6,  Codigo="EST006", Nombres="Carlos",    Apellidos="Herrera",  Grado=2, Estado="Activo"   },
            new Estudiante { Id=7,  Codigo="EST007", Nombres="Sofía",     Apellidos="Vargas",   Grado=2, Estado="Inactivo" },
            new Estudiante { Id=8,  Codigo="EST008", Nombres="Diego",     Apellidos="Castro",   Grado=2, Estado="Activo"   },
            new Estudiante { Id=9,  Codigo="EST009", Nombres="Valentina", Apellidos="Morales",  Grado=3, Estado="Activo"   },
            new Estudiante { Id=10, Codigo="EST010", Nombres="Andrés",    Apellidos="Jiménez",  Grado=3, Estado="Activo"   },
            new Estudiante { Id=11, Codigo="EST011", Nombres="Isabella",  Apellidos="Rojas",    Grado=3, Estado="Activo"   },
            new Estudiante { Id=12, Codigo="EST012", Nombres="Sebastián", Apellidos="Mendoza",  Grado=3, Estado="Inactivo" },
            new Estudiante { Id=13, Codigo="EST013", Nombres="Camila",    Apellidos="Ríos",     Grado=4, Estado="Activo"   },
            new Estudiante { Id=14, Codigo="EST014", Nombres="Felipe",    Apellidos="Peña",     Grado=4, Estado="Activo"   },
            new Estudiante { Id=15, Codigo="EST015", Nombres="Natalia",   Apellidos="Salinas",  Grado=4, Estado="Activo"   },
            new Estudiante { Id=16, Codigo="EST016", Nombres="Mateo",     Apellidos="Cruz",     Grado=4, Estado="Inactivo" },
            new Estudiante { Id=17, Codigo="EST017", Nombres="Daniela",   Apellidos="Flores",   Grado=5, Estado="Activo"   },
            new Estudiante { Id=18, Codigo="EST018", Nombres="Santiago",  Apellidos="Reyes",    Grado=5, Estado="Activo"   },
            new Estudiante { Id=19, Codigo="EST019", Nombres="Gabriela",  Apellidos="Soto",     Grado=5, Estado="Activo"   },
            new Estudiante { Id=20, Codigo="EST020", Nombres="Nicolás",   Apellidos="Medina",   Grado=5, Estado="Inactivo" },
        };

        public static List<Docente> Docentes() => new()
        {
            new Docente { Id=1, Nombres="Jorge",    Apellidos="García",   Correo="j.garcia@educlick.co",   Telefono="3101234567", Especialidad="Matemáticas",       Estado="Activo"   },
            new Docente { Id=2, Nombres="Patricia", Apellidos="López",    Correo="p.lopez@educlick.co",    Telefono="3209876543", Especialidad="Español",            Estado="Activo"   },
            new Docente { Id=3, Nombres="Ricardo",  Apellidos="Martínez", Correo="r.martinez@educlick.co", Telefono="3154567890", Especialidad="Ciencias Naturales", Estado="Activo"   },
            new Docente { Id=4, Nombres="Sandra",   Apellidos="Torres",   Correo="s.torres@educlick.co",   Telefono="3001112233", Especialidad="Ciencias Sociales",  Estado="Inactivo" },
            new Docente { Id=5, Nombres="Mauricio", Apellidos="Herrera",  Correo="m.herrera@educlick.co",  Telefono="3123334455", Especialidad="Inglés",             Estado="Activo"   },
            new Docente { Id=6, Nombres="Claudia",  Apellidos="Vargas",   Correo="c.vargas@educlick.co",   Telefono="3176665544", Especialidad="Educación Física",   Estado="Activo"   },
            new Docente { Id=7, Nombres="Héctor",   Apellidos="Castro",   Correo="h.castro@educlick.co",   Telefono="3187778899", Especialidad="Arte",               Estado="Activo"   },
            new Docente { Id=8, Nombres="Liliana",  Apellidos="Morales",  Correo="l.morales@educlick.co",  Telefono="3219990011", Especialidad="Tecnología",         Estado="Inactivo" },
        };

        public static List<Acudiente> Acudientes() => new()
        {
            new Acudiente { Id=1,  Nombres="Rosa",    Apellidos="García",   Direccion="Calle 10 #5-20",   Telefono="3101111111", NombreEstudiante="Ana García",       Estado="Activo"   },
            new Acudiente { Id=2,  Nombres="Marco",   Apellidos="Martínez", Direccion="Carrera 8 #12-34", Telefono="3202222222", NombreEstudiante="Luis Martínez",    Estado="Activo"   },
            new Acudiente { Id=3,  Nombres="Elena",   Apellidos="López",    Direccion="Av. 15 #22-10",    Telefono="3153333333", NombreEstudiante="María López",      Estado="Inactivo" },
            new Acudiente { Id=4,  Nombres="Ernesto", Apellidos="Ramírez",  Direccion="Calle 45 #8-90",   Telefono="3004444444", NombreEstudiante="Pedro Ramírez",    Estado="Activo"   },
            new Acudiente { Id=5,  Nombres="Gloria",  Apellidos="Torres",   Direccion="Carrera 20 #3-15", Telefono="3125555555", NombreEstudiante="Laura Torres",     Estado="Activo"   },
            new Acudiente { Id=6,  Nombres="Alfredo", Apellidos="Herrera",  Direccion="Calle 67 #11-22",  Telefono="3176666666", NombreEstudiante="Carlos Herrera",   Estado="Activo"   },
            new Acudiente { Id=7,  Nombres="Beatriz", Apellidos="Vargas",   Direccion="Av. 30 #18-44",    Telefono="3187777777", NombreEstudiante="Sofía Vargas",     Estado="Inactivo" },
            new Acudiente { Id=8,  Nombres="Rodrigo", Apellidos="Castro",   Direccion="Calle 12 #7-33",   Telefono="3218888888", NombreEstudiante="Diego Castro",     Estado="Activo"   },
            new Acudiente { Id=9,  Nombres="Carmen",  Apellidos="Morales",  Direccion="Carrera 5 #25-60", Telefono="3109999999", NombreEstudiante="Valentina Morales",Estado="Activo"   },
            new Acudiente { Id=10, Nombres="Jaime",   Apellidos="Jiménez",  Direccion="Av. 68 #14-28",    Telefono="3200000001", NombreEstudiante="Andrés Jiménez",   Estado="Activo"   },
        };
        public static List<Usuarios> Usuarios() => new()
{
    new Usuarios {
        IdUsuario = 1,
        Nombres = "Carlos",
        Apellidos = "Martínez",
        Correo = "c.martinez@educlick.co",
        Rol = "Rector",
        Estado = "Activo",
        FechaRegistro = new DateTime(2024,1,15)
    },
    new Usuarios {
        IdUsuario = 2,
        Nombres = "Jorge",
        Apellidos = "García",
        Correo = "j.garcia@educlick.co",
        Rol = "Docente",
        Estado = "Activo",
        FechaRegistro = new DateTime(2024,1,20)
    },
    new Usuarios {
        IdUsuario = 3,
        Nombres = "Patricia",
        Apellidos = "López",
        Correo = "p.lopez@educlick.co",
        Rol = "Docente",
        Estado = "Activo",
        FechaRegistro = new DateTime(2024,2,1)
    },
    new Usuarios {
        IdUsuario = 4,
        Nombres = "Andrea",
        Apellidos = "Suárez",
        Correo = "a.suarez@educlick.co",
        Rol = "Secretaria",
        Estado = "Activo",
        FechaRegistro = new DateTime(2024,2,10)
    },
    new Usuarios {
        IdUsuario = 5,
        Nombres = "Miguel",
        Apellidos = "Peña",
        Correo = "m.pena@educlick.co",
        Rol = "Docente",
        Estado = "Pendiente",
        FechaRegistro = new DateTime(2024,5,20)
    },
    new Usuarios {
        IdUsuario = 6,
        Nombres = "Luisa",
        Apellidos = "Ramos",
        Correo = "l.ramos@educlick.co",
        Rol = "Docente",
        Estado = "Pendiente",
        FechaRegistro = new DateTime(2024,5,22)
    },
    new Usuarios {
        IdUsuario = 7,
        Nombres = "Fernando",
        Apellidos = "Cruz",
        Correo = "f.cruz@educlick.co",
        Rol = "Secretaria",
        Estado = "Pendiente",
        FechaRegistro = new DateTime(2024,5,25)
    },
    new Usuarios {
        IdUsuario = 8,
        Nombres = "Teresa",
        Apellidos = "Molina",
        Correo = "t.molina@educlick.co",
        Rol = "Docente",
        Estado = "Bloqueado",
        FechaRegistro = new DateTime(2024,3,5)
    }
};


        public static List<RolViewModel> Roles() => new()
{
            new RolViewModel { Id=1, Nombre="Rector",      Descripcion="Acceso total al sistema",                    VerDashboard=true,  GestionUsuarios=true,  GestionAcademico=true,  VerReportes=true,  EditarNotas=false, Estado="Activo" },
            new RolViewModel { Id=2, Nombre="Docente",      Descripcion="Gestiona cursos, materias y notas",          VerDashboard=true,  GestionUsuarios=false, GestionAcademico=true,  VerReportes=false, EditarNotas=true,  Estado="Activo" },
            new RolViewModel { Id=3, Nombre="Secretaria",   Descripcion="Gestiona estudiantes y acudientes",          VerDashboard=true,  GestionUsuarios=false, GestionAcademico=true,  VerReportes=true,  EditarNotas=false, Estado="Activo" },new RolViewModel { Id=4, Nombre="Estudiante",   Descripcion="Ve sus notas y boletines",                   VerDashboard=false, GestionUsuarios=false, GestionAcademico=false, VerReportes=false, EditarNotas=false, Estado="Activo" },
            new RolViewModel { Id=5, Nombre="Acudiente",    Descripcion="Ve el boletín de su hijo",                   VerDashboard=false, GestionUsuarios=false, GestionAcademico=false, VerReportes=false, EditarNotas=false, Estado="Activo" },
            new RolViewModel { Id=6, Nombre="Administrador",Descripcion="Administra la plataforma técnicamente",      VerDashboard=true,  GestionUsuarios=true,  GestionAcademico=false, VerReportes=true,  EditarNotas=false, Estado="Activo" },
        };

        public static List<ModuloViewModel> Modulos() => new()
{
            new ModuloViewModel { Id=1, Nombre="Dashboard",    Descripcion="Vista principal con estadísticas",       Icono="ti-layout-dashboard", Estado="Activo",   RolesConAcceso=new(){"Rector","Docente","Secretaria","Administrador"} },
            new ModuloViewModel { Id=2, Nombre="Estudiantes",  Descripcion="Gestión de estudiantes",                 Icono="ti-backpack",         Estado="Activo",   RolesConAcceso=new(){"Rector","Secretaria"} },
            new ModuloViewModel { Id=3, Nombre="Docentes",     Descripcion="Gestión de docentes",                    Icono="ti-chalkboard",       Estado="Activo",   RolesConAcceso=new(){"Rector","Administrador"} },
            new ModuloViewModel { Id=4, Nombre="Acudientes",   Descripcion="Gestión de acudientes",                  Icono="ti-users-group",      Estado="Activo",   RolesConAcceso=new(){"Rector","Secretaria"} },
            new ModuloViewModel { Id=5, Nombre="Cursos",       Descripcion="Gestión de cursos académicos",           Icono="ti-books",            Estado="Activo",   RolesConAcceso=new(){"Rector","Docente","Secretaria"} },
            new ModuloViewModel { Id=6, Nombre="Materias",     Descripcion="Gestión de materias",                    Icono="ti-book",             Estado="Activo",   RolesConAcceso=new(){"Rector","Docente"} },
            new ModuloViewModel { Id=7, Nombre="Notas",        Descripcion="Registro y consulta de notas",           Icono="ti-pencil",           Estado="Activo",   RolesConAcceso=new(){"Rector","Docente","Estudiante"} },
            new ModuloViewModel { Id=8, Nombre="Periodos",     Descripcion="Gestión de períodos académicos",         Icono="ti-calendar",         Estado="Activo",   RolesConAcceso=new(){"Rector"} },
            new ModuloViewModel { Id=9, Nombre="Boletines",    Descripcion="Generación y consulta de boletines",     Icono="ti-file-description", Estado="Activo",   RolesConAcceso=new(){"Rector","Docente","Estudiante","Acudiente"} },
            new ModuloViewModel { Id=10,Nombre="Usuarios",     Descripcion="Gestión de usuarios del sistema",        Icono="ti-users",            Estado="Activo",   RolesConAcceso=new(){"Rector","Administrador"} },
            new ModuloViewModel { Id=11,Nombre="Roles",        Descripcion="Gestión de roles y permisos",            Icono="ti-key",              Estado="Activo",   RolesConAcceso=new(){"Rector","Administrador"} },
            new ModuloViewModel { Id=12,Nombre="Módulos",      Descripcion="Activar o desactivar módulos",           Icono="ti-puzzle",           Estado="Activo",   RolesConAcceso=new(){"Rector","Administrador"} },
        };

        public static List<CursoViewModel> Cursos() => new()
{
    new CursoViewModel { Id=1, Nombre="1° A", Grado=1, Docente="Prof. García",  NumEstudiantes=30, Periodo="2024-1", Promedio=7.8, Estado="Activo"   },
    new CursoViewModel { Id=2, Nombre="1° B", Grado=1, Docente="Prof. López",   NumEstudiantes=28, Periodo="2024-1", Promedio=6.9, Estado="Activo"   },
    new CursoViewModel { Id=3, Nombre="2° A", Grado=2, Docente="Prof. Ruiz",    NumEstudiantes=29, Periodo="2024-1", Promedio=5.4, Estado="Alerta"   },
    new CursoViewModel { Id=4, Nombre="2° B", Grado=2, Docente="Prof. Mora",    NumEstudiantes=31, Periodo="2024-1", Promedio=8.1, Estado="Activo"   },
    new CursoViewModel { Id=5, Nombre="3° A", Grado=3, Docente="Prof. Díaz",    NumEstudiantes=27, Periodo="2024-1", Promedio=7.2, Estado="Revisión" },
    new CursoViewModel { Id=6, Nombre="3° B", Grado=3, Docente="Prof. Vargas",  NumEstudiantes=30, Periodo="2024-1", Promedio=7.5, Estado="Activo"   },
    new CursoViewModel { Id=7, Nombre="4° A", Grado=4, Docente="Prof. Castro",  NumEstudiantes=28, Periodo="2024-1", Promedio=8.3, Estado="Activo"   },
    new CursoViewModel { Id=8, Nombre="4° B", Grado=4, Docente="Prof. Morales", NumEstudiantes=29, Periodo="2024-1", Promedio=6.5, Estado="Activo"   },
    new CursoViewModel { Id=9, Nombre="5° A", Grado=5, Docente="Prof. Herrera", NumEstudiantes=31, Periodo="2024-1", Promedio=7.9, Estado="Activo"   },
    new CursoViewModel { Id=10,Nombre="5° B", Grado=5, Docente="Prof. Torres",  NumEstudiantes=27, Periodo="2024-1", Promedio=6.1, Estado="Alerta"   },
};

        public static List<MateriaViewModel> Materias() => new()
{
    new MateriaViewModel { Id=1,  Nombre="Matemáticas",        Descripcion="Aritmética y geometría básica",      Grado=1, Docente="Jorge García",    HorasSemana=5, Estado="Activo" },
    new MateriaViewModel { Id=2,  Nombre="Español",            Descripcion="Lectura, escritura y comprensión",   Grado=1, Docente="Patricia López",  HorasSemana=5, Estado="Activo" },
    new MateriaViewModel { Id=3,  Nombre="Ciencias Naturales",  Descripcion="Introducción a las ciencias",        Grado=2, Docente="Ricardo Martínez",HorasSemana=4, Estado="Activo" },
    new MateriaViewModel { Id=4,  Nombre="Ciencias Sociales",   Descripcion="Historia y geografía",               Grado=2, Docente="Sandra Torres",   HorasSemana=4, Estado="Inactivo" },
    new MateriaViewModel { Id=5,  Nombre="Inglés",              Descripcion="Idioma extranjero básico",           Grado=3, Docente="Mauricio Herrera",HorasSemana=3, Estado="Activo" },
    new MateriaViewModel { Id=6,  Nombre="Educación Física",    Descripcion="Actividad física y deporte",         Grado=3, Docente="Claudia Vargas",  HorasSemana=2, Estado="Activo" },
    new MateriaViewModel { Id=7,  Nombre="Arte",                Descripcion="Expresión artística y manualidades", Grado=4, Docente="Héctor Castro",   HorasSemana=2, Estado="Activo" },
    new MateriaViewModel { Id=8,  Nombre="Tecnología",          Descripcion="Informática básica",                 Grado=4, Docente="Liliana Morales", HorasSemana=2, Estado="Inactivo" },
    new MateriaViewModel { Id=9,  Nombre="Matemáticas",         Descripcion="Operaciones y problemas",            Grado=5, Docente="Jorge García",    HorasSemana=5, Estado="Activo" },
    new MateriaViewModel { Id=10, Nombre="Español",             Descripcion="Producción de textos",               Grado=5, Docente="Patricia López",  HorasSemana=5, Estado="Activo" },
};

        public static List<NOTARectorViewModel> Notas() => new()
{
    new NOTARectorViewModel { Id=1, CodigoEstudiante="EST001", NombreEstudiante="Ana García",     Curso="1° A", Grado=1, Materia="Matemáticas", Docente="Jorge García",   Periodo1=7.5, Periodo2=8.0, Periodo3=7.8, Periodo4=8.2, Asistencias=58, Faltas=2 },
    new NOTARectorViewModel { Id=2, CodigoEstudiante="EST001", NombreEstudiante="Ana García",     Curso="1° A", Grado=1, Materia="Español",     Docente="Patricia López", Periodo1=8.0, Periodo2=7.5, Periodo3=8.5, Periodo4=8.0, Asistencias=60, Faltas=0 },
    new NOTARectorViewModel { Id=3, CodigoEstudiante="EST002", NombreEstudiante="Luis Martínez",  Curso="1° A", Grado=1, Materia="Matemáticas", Docente="Jorge García",   Periodo1=6.0, Periodo2=5.5, Periodo3=6.2, Periodo4=5.8, Asistencias=55, Faltas=5 },
    new NOTARectorViewModel { Id=4, CodigoEstudiante="EST002", NombreEstudiante="Luis Martínez",  Curso="1° A", Grado=1, Materia="Español",     Docente="Patricia López", Periodo1=7.0, Periodo2=6.8, Periodo3=7.2, Periodo4=7.0, Asistencias=57, Faltas=3 },
    new NOTARectorViewModel { Id=5, CodigoEstudiante="EST003", NombreEstudiante="María López",    Curso="1° A", Grado=1, Materia="Matemáticas", Docente="Jorge García",   Periodo1=4.0, Periodo2=4.5, Periodo3=4.2, Periodo4=4.0, Asistencias=40, Faltas=20 },
    new NOTARectorViewModel { Id=6, CodigoEstudiante="EST005", NombreEstudiante="Laura Torres",   Curso="2° A", Grado=2, Materia="Ciencias Naturales", Docente="Ricardo Martínez", Periodo1=8.5, Periodo2=8.8, Periodo3=8.2, Periodo4=8.6, Asistencias=59, Faltas=1 },
    new NOTARectorViewModel { Id=7, CodigoEstudiante="EST005", NombreEstudiante="Laura Torres",   Curso="2° A", Grado=2, Materia="Ciencias Sociales",  Docente="Sandra Torres",    Periodo1=7.8, Periodo2=8.0, Periodo3=7.5, Periodo4=8.0, Asistencias=58, Faltas=2 },
    new NOTARectorViewModel { Id=8, CodigoEstudiante="EST006", NombreEstudiante="Carlos Herrera", Curso="2° A", Grado=2, Materia="Ciencias Naturales", Docente="Ricardo Martínez", Periodo1=6.5, Periodo2=6.0, Periodo3=6.8, Periodo4=6.2, Asistencias=54, Faltas=6 },
    new NOTARectorViewModel { Id=9, CodigoEstudiante="EST009", NombreEstudiante="Valentina Morales", Curso="3° A", Grado=3, Materia="Inglés",           Docente="Mauricio Herrera", Periodo1=9.0, Periodo2=8.8, Periodo3=9.2, Periodo4=9.0, Asistencias=60, Faltas=0 },
    new NOTARectorViewModel { Id=10,CodigoEstudiante="EST009", NombreEstudiante="Valentina Morales", Curso="3° A", Grado=3, Materia="Educación Física", Docente="Claudia Vargas",   Periodo1=9.5, Periodo2=9.0, Periodo3=9.8, Periodo4=9.5, Asistencias=60, Faltas=0 },
    new NOTARectorViewModel { Id=11,CodigoEstudiante="EST010", NombreEstudiante="Andrés Jiménez", Curso="3° A", Grado=3, Materia="Inglés",           Docente="Mauricio Herrera", Periodo1=5.0, Periodo2=4.8, Periodo3=5.2, Periodo4=5.5, Asistencias=50, Faltas=10 },
};

        public static List<PeriodoViewModel> Periodos() => new()
{
    new PeriodoViewModel { Id=1, Nombre="Período 1", FechaInicio=new DateTime(2024,1,29), FechaFin=new DateTime(2024,4,12), Estado="Cerrado", AnioEscolar="2024" },
    new PeriodoViewModel { Id=2, Nombre="Período 2", FechaInicio=new DateTime(2024,4,15), FechaFin=new DateTime(2024,6,21), Estado="Activo", AnioEscolar="2024" },
    new PeriodoViewModel { Id=3, Nombre="Período 3", FechaInicio=new DateTime(2024,7,8),  FechaFin=new DateTime(2024,9,20), Estado="Próximo", AnioEscolar="2024" },
    new PeriodoViewModel { Id=4, Nombre="Período 4", FechaInicio=new DateTime(2024,9,23), FechaFin=new DateTime(2024,11,29), Estado="Próximo", AnioEscolar="2024" },
};
    }
}