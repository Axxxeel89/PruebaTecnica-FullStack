export interface usuarios{
  id: string | null,
  Nombres: string,
  Apellidos: string,
  rol: string,
  email: string,
  userName: string,
  token: string,
  password: string
}

export interface usuariosLoginDto{
  email: string,
  password: string
}

export interface usuarioRegisterDto {
  Nombres: string,
  Apellidos: string,
  rol: string | null,
  email: string | null,
  userName: string | null,
  password: string | null
}
